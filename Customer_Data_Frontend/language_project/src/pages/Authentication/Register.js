import React, { useState } from "react";
import Button from "react-bootstrap/Button";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Row from "react-bootstrap/Row";
import { useNavigate } from "react-router-dom";
import WarningAlert from "../../components/WarningAlert";

const Register = () => {
  const navigate = useNavigate();
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [role, setRole] = useState("");
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

    if (!confirmPassword.match(password)) {
      formIsValid = false;
      setpasswordError("Does not match entered passwords!");
      return false;
    } else {
      setpasswordError("");
      formIsValid = true;
    }
    return formIsValid;
  };

  const registerSubmit = (e) => {
    e.preventDefault();
    if (handleValidation()) {
      const requestData = new FormData();
      requestData.append("Name", name);
      requestData.append("Email", email);
      requestData.append("PhoneNumber", phoneNumber);
      requestData.append("Password", password);
      requestData.append("ConfirmPassword", confirmPassword);
      requestData.append("Role", role);

      fetch(`https://localhost:7018/api/Account/Register`, {
        method: "POST",
        body: requestData,
      })
        .then((response) => {
          if (response.ok) {
            return response;
          } else {
            throw new Error("API call failed");
          }
        })
        .then((data) => {
          navigate(`/`);
        })
        .catch((error) => {
          console.error("API call error:", error);
          setShowAlert(true);
        });
    }
  };

  return (
    <div className="register_container">
      <Form className="register_form" onSubmit={registerSubmit}>
        <Form.Group className="mb-3" controlId="formGridEmail">
          <Form.Label>Email</Form.Label>
          <Form.Control
            type="email"
            placeholder="Enter email"
            onChange={(event) => setEmail(event.target.value)}
          />
        </Form.Group>
        <Row className="mb-3">
          <Form.Group as={Col} controlId="formGridName">
            <Form.Label>Name</Form.Label>
            <Form.Control
              placeholder="Kevin Peret"
              onChange={(event) => setName(event.target.value)}
            />
          </Form.Group>
          <Form.Group as={Col} controlId="formGridMobile">
            <Form.Label>Phone Number</Form.Label>
            <Form.Control
              placeholder="+94 77 860 1398"
              onChange={(event) => setPhoneNumber(event.target.value)}
            />
          </Form.Group>
        </Row>
        <Row className="mb-3">
          <Form.Group as={Col} controlId="formGridPassword">
            <Form.Label>Password</Form.Label>
            <Form.Control
              type="password"
              placeholder="Password"
              onChange={(event) => setPassword(event.target.value)}
            />
          </Form.Group>
          <Form.Group as={Col} controlId="formGridConfirmPassword">
            <Form.Label>Confirm Password</Form.Label>
            <Form.Control
              type="password"
              placeholder="Password"
              onChange={(event) => setConfirmPassword(event.target.value)}
            />
          </Form.Group>
        </Row>

        <Form.Group className="mb-3" controlId="formGridRole">
          <Form.Label>Role</Form.Label>
          <Form.Control
            placeholder="Enter role"
            onChange={(event) => setRole(event.target.value)}
          />
        </Form.Group>

        <Button variant="primary" type="submit">
          Register
        </Button>
      </Form>
      {showAlert && <WarningAlert />}
    </div>
  );
};

export default Register;
