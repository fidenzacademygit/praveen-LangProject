import React from "react";
import Button from "react-bootstrap/Button";
import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";
import Row from "react-bootstrap/Row";

const EditCustomerPage = () => {
  return (
    <div id="cutomers" className="dashboard_container">
      <Form className="edit-page">
        <Form.Group className="mb-3" controlId="formGridName">
          <Form.Label>Name</Form.Label>
          <Form.Control placeholder="Kevin" />
        </Form.Group>

        <Form.Group className="mb-3" controlId="formGridName">
          <Form.Label>Age</Form.Label>
          <Form.Control type="number" placeholder="45" />
        </Form.Group>

        <Form.Group className="mb-3" controlId="formGridName">
          <Form.Label>Eye Colour</Form.Label>
          <Form.Control placeholder="Green" />
        </Form.Group>

        <Form.Group className="mb-3" controlId="formGridName">
          <Form.Label>Gender</Form.Label>
          <Form.Control placeholder="Male" />
        </Form.Group>

        <Form.Group className="mb-3" controlId="formGridName">
          <Form.Label>Company</Form.Label>
          <Form.Control placeholder="Fidenz" />
        </Form.Group>

        <Form.Group className="mb-3" controlId="formGridName">
          <Form.Label>Phone Number</Form.Label>
          <Form.Control placeholder="+78-456-4568" />
        </Form.Group>

        <Form.Group className="mb-3" controlId="formGridEmail">
          <Form.Label>Email</Form.Label>
          <Form.Control type="email" placeholder="Enter email" />
        </Form.Group>

        <Form.Label>Address</Form.Label>

        <Row className="mb-3">
          <Form.Group as={Col} controlId="formGridCity">
            <Form.Label>City</Form.Label>
            <Form.Control />
          </Form.Group>

          <Form.Group as={Col} controlId="formGridState">
            <Form.Label>State</Form.Label>
            <Form.Control />
          </Form.Group>

          <Form.Group as={Col} controlId="formGridZip">
            <Form.Label>Zipcode</Form.Label>
            <Form.Control />
          </Form.Group>
        </Row>

        <Row className="mb-3">
          <Form.Group as={Col} controlId="formGridCity">
            <Form.Label>Street</Form.Label>
            <Form.Control />
          </Form.Group>

          <Form.Group as={Col} controlId="formGridZip">
            <Form.Label>Number</Form.Label>
            <Form.Control type="number" />
          </Form.Group>
        </Row>

        <Form.Group className="mb-3" controlId="formGridName">
          <Form.Label>About</Form.Label>
          <Form.Control placeholder="About Customer" />
        </Form.Group>

        <Form.Group className="mb-3" controlId="formGridName">
          <Form.Label>Latitude</Form.Label>
          <Form.Control type="number" placeholder="Kevin" />
        </Form.Group>

        <Form.Group className="mb-3" controlId="formGridName">
          <Form.Label>Longitude</Form.Label>
          <Form.Control type="number" placeholder="Kevin" />
        </Form.Group>

        <Button variant="primary" type="submit">
          Submit
        </Button>
      </Form>
    </div>
  );
};

export default EditCustomerPage;
