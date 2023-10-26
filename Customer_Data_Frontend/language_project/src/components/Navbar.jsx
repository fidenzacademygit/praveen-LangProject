import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";

function CollapsibleExample() {
  return (
    <Navbar collapseOnSelect expand="lg" className="nav">
      <Container>
        <Navbar.Brand href="#home">
          <p className="txt">Language Project</p>
        </Navbar.Brand>
        <Navbar.Toggle
          aria-controls="responsive-navbar-nav"
          className="nav-toggle"
        />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="#">
              <p className="txt">Home</p>
            </Nav.Link>
            <Nav.Link href="#">
              <p className="txt">Customer List</p>
            </Nav.Link>
            <NavDropdown title="Droopdown" id="collapsible-nav-dropdown">
              <NavDropdown.Item href="#">
                <p className="txt">Another Action</p>
              </NavDropdown.Item>
              <NavDropdown.Item href="#">
                <p className="txt">Something</p>
              </NavDropdown.Item>          
            </NavDropdown>
          </Nav>
          <Nav>
            <Nav.Link href="#">
              <p className="txt">Register</p>
            </Nav.Link>
            <Nav.Link href="#">
              <p className="txt">Login</p>
            </Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default CollapsibleExample;
