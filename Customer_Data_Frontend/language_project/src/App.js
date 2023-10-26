import "./App.css";
import Dashboard from "./pages/Dashboard";
import Footer from "./components/Footer";
import Navbar from "./components/Navbar";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Login from "./pages/Authentication/Login";
import CustomerList from "./pages/CustomerList";
import EditCustomer from "./pages/EditCustomer";
import GetDistance from "./pages/GetDistance";
import SearchCustomer from "./pages/SearchCustomer";
import GroupedCustomers from "./pages/GroupedCustomers";
import EditCustomerPage from "./pages/EditCustomerPage";
import React, { useEffect, useState } from "react";

function App() {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [userRole, setUserRole] = useState(null);
  const [userEmail, setUserEmail] = useState(null);

  useEffect(() => {
    const Token = localStorage.getItem("authToken");
    const Role = localStorage.getItem("authRole");
    const Email = localStorage.getItem("authEmail");

    if (Token) {
      setIsAuthenticated(true);
      setUserRole(Role);
      setUserEmail(Email);
    }
  }, []);

  return (
    <Router>
      <div className="my_app">
        <Navbar
          isAuthenticated={isAuthenticated}
          userRole={userRole}
          userEmail={userEmail}
          setIsAuthenticated={setIsAuthenticated}
          setUserRole={setUserRole}
          setUserEmail={setUserEmail}
        />
        <Routes>
          <Route
            exact
            path="/"
            element={
              <Login
                setIsAuthenticated={setIsAuthenticated}
                setUserRole={setUserRole}
                setUserEmail={setUserEmail}
              />
            }
          />
          <Route exact path="/Dashboard" element={<Dashboard />} />
          <Route exact path="/CustomerList" element={<CustomerList />} />
          <Route exact path="/EditCustomer" element={<EditCustomer />} />
          <Route exact path="/GetDistance" element={<GetDistance />} />
          <Route exact path="/SearchCustomer" element={<SearchCustomer />} />
          <Route exact path="/GroupedCustomer" element={<GroupedCustomers />} />
          <Route exact path="/EditCustomerPage"element={<EditCustomerPage />}/>
        </Routes>
        <Footer />
      </div>
    </Router>
  );
}

export default App;
