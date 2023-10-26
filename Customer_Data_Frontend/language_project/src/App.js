import "./App.css";
import Dashboard from "./pages/Dashboard";
import Footer from "./components/Footer";
import Navbar from "./components/Navbar";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Register from "./pages/Authentication/Register";
import Login from "./pages/Authentication/Login";
import CustomerList from "./pages/CustomerList";

function App() {
  return (
    <Router>
      <div className="my_app">
      <Navbar/>
        <Routes>
          <Route exact path="/" element={<Dashboard />} />
          <Route exact path="/Register" element={<Register />} />
          <Route exact path="/Login" element={<Login />} />
          <Route exact path="/CustomerList" element={<CustomerList />} />
        </Routes>
        <Footer />
      </div>
    </Router>
  );
}

export default App;
