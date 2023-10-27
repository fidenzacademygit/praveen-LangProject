import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { accessToken, apiUrl } from "../../types/APIHelper";
import { useNavigate } from "react-router-dom";
import jwtDecode from "jwt-decode";
import WarningAlert from "../../components/WarningAlert";

const Login = ({ setIsAuthenticated, setUserRole, setUserEmail }) => {
  const navigate = useNavigate();
  const [password, setPassword] = useState("");
  const [email, setEmail] = useState("");
  const [passwordError, setpasswordError] = useState("");
  const [emailError, setemailError] = useState("");
  const [showAlert, setShowAlert] = useState(false);

  const handleValidation = (event) => {
    let formIsValid = true;

    if (!email.match(/^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/)) {
      formIsValid = false;
      setemailError("Email Not Valid");
      return false;
    } else {
      setemailError("");
      formIsValid = true;
    }

    if (!password.match(/^.{8,22}$/)) {
      formIsValid = false;
      setpasswordError(
        "Only Letters and length must best min 8 Chracters and Max 22 Chracters"
      );
      return false;
    } else {
      setpasswordError("");
      formIsValid = true;
    }
    return formIsValid;
  };

  const loginSubmit = (e) => {
    e.preventDefault();
    if (handleValidation()) {
      const requestData = new FormData();
      requestData.append("Email", email);
      requestData.append("Password", password);

      fetch(`${apiUrl}/UserLogin/Login`, {
        method: "POST",
        headers: {
          Authorization: `Bearer ${accessToken}`,
        },
        body: requestData,
      })
        .then((response) => {
          if (response.ok) {
            return response.json();
          } else {
            throw new Error("API call failed");
          }
        })
        .then((data) => {
          const token = data.token;

          if (token) {
            setIsAuthenticated(true);

            const decodedToken = jwtDecode(token);
            const userRole =
              decodedToken[
                "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
              ];
            const userEmail =
              decodedToken[
                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"
              ];
            localStorage.setItem("authToken", token);
            localStorage.setItem("authRole", userRole);
            setUserRole(userRole);
            localStorage.setItem("authEmail", userEmail);
            setUserEmail(userEmail);
          }

          navigate(`/Dashboard`);
        })
        .catch((error) => {
          console.error("API call error:", error);
          setShowAlert(true);
        });
    }
  };
  return (
    <div className="login_container">
      <div className="col-md-4">
        <form id="loginform" onSubmit={loginSubmit}>
          <div className="form-group">
            <label>Email address</label>
            <input
              type="email"
              className="form-control"
              id="EmailInput"
              name="EmailInput"
              aria-describedby="emailHelp"
              placeholder="Enter email"
              onChange={(event) => setEmail(event.target.value)}
            />
            <small id="emailHelp" className="text-danger form-text">
              {emailError}
            </small>
          </div>
          <div className="form-group">
            <label>Password</label>
            <input
              type="password"
              className="form-control"
              id="exampleInputPassword1"
              placeholder="Password"
              onChange={(event) => setPassword(event.target.value)}
            />
            <small id="passworderror" className="text-danger form-text">
              {passwordError}
            </small>
          </div>
          <div className="form-group form-check">
            <input
              type="checkbox"
              className="form-check-input"
              id="exampleCheck1"
            />
            <label className="form-check-label">Remember Me</label>
          </div>
          <button type="submit" className="btn btn-primary">
            Login
          </button>
        </form>
      </div>
      {showAlert && <WarningAlert />}
    </div>
  );
};

export default Login;
