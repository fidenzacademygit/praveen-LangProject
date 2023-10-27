import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";
import { Link, useNavigate } from "react-router-dom";

function CollapsibleExample({ isAuthenticated, userRole, userEmail , setIsAuthenticated, setUserRole, setUserEmail}) {

  const navigate = useNavigate();

  const handleLogout = () => {
    localStorage.removeItem('authToken');
    localStorage.removeItem('authRole');
    localStorage.removeItem('authEmail');
    setUserRole(null);
    setUserEmail(null);
    navigate('/');
  };

  return (
    <Navbar collapseOnSelect expand="lg" className="nav">
      <Container>
        <Navbar.Brand href="#">
          <p className="txt">Language Project</p>
        </Navbar.Brand>
        <Navbar.Toggle
          aria-controls="responsive-navbar-nav"
          className="nav-toggle"
        />
        <Navbar.Collapse id="responsive-navbar-nav">
          {isAuthenticated  ? (
            <Nav className="me-auto">
            <NavDropdown title="Features" id="collapsible-nav-dropdown">
              <NavDropdown.Item as={Link} to="/CustomerList">
                <p className="txt">Customer List</p>
              </NavDropdown.Item>
              <NavDropdown.Item as={Link} to="/EditCustomer">
                <p className="txt">Edit Customer</p>
              </NavDropdown.Item>
              <NavDropdown.Item as={Link} to="/GetDistance">
                <p className="txt">Get Distance</p>
              </NavDropdown.Item>
              <NavDropdown.Item as={Link} to="/SearchCustomer">
                <p className="txt">Search Customer</p>
              </NavDropdown.Item>
              <NavDropdown.Item as={Link} to="/GroupedCustomer">
                <p className="txt">Customers Group By Zipcode</p>
              </NavDropdown.Item>
            </NavDropdown>
          </Nav>
          ) : (
            <Nav className="me-auto">
            <NavDropdown title="Features" id="collapsible-nav-dropdown">
              <NavDropdown.Item as={Link} to="/">
                <p className="txt">Customer List</p>
              </NavDropdown.Item>
              <NavDropdown.Item as={Link} to="/">
                <p className="txt">Edit Customer</p>
              </NavDropdown.Item>
              <NavDropdown.Item as={Link} to="/">
                <p className="txt">Get Distance</p>
              </NavDropdown.Item>
              <NavDropdown.Item as={Link} to="/">
                <p className="txt">Search Customer</p>
              </NavDropdown.Item>
              <NavDropdown.Item as={Link} to="/">
                <p className="txt">Customers Group By Zipcode</p>
              </NavDropdown.Item>
            </NavDropdown>
          </Nav>
          )}
          <Nav>
            {isAuthenticated ? (
              <div className="nav-details">
                <p className="txt">Hello, {userEmail}</p>
                <Nav.Link onClick={handleLogout}>
                  <p className="txt">Logout</p>
                </Nav.Link>
              </div>               
            ) : (
              <Nav.Link href="#">
                <p className="txt"></p>
              </Nav.Link>
            )}
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default CollapsibleExample;
