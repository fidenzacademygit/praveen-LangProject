import axios from "axios";
import React from "react";
import { useCallback } from "react";
import { useState, useEffect } from "react";
import Table from "react-bootstrap/Table";

const accessToken =
  "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbjEyMzRAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE2OTg5MDE5MDYsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcwMTgiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo3MDE4In0.gfvTUeq_tHUeKh4mVEeG8NGBkzGyhuCW2uLSWhpmSyR0ATBt0CjiHhI1rwwCSTXLPal3GZ2_B-HiFCjUJ2GlrQ";

const apiUrl = "https://localhost:7018/api/v1";

axios.interceptors.request.use(
  (config) => {
    config.headers.authorization = `Bearer ${accessToken}`;
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

const CustomerTable = () => {
  const [customers, setCustomers] = useState([]);
  const [requestError, setRequestError] = useState();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const result = await axios.get(`${apiUrl}/Admin/GetAllCustomers`);
        setCustomers(result.data);
      } catch (err) {
        setRequestError(err.message);
      }
    };

    fetchData();
  }, []);

  return (
    <div className="customers-div">
      <div className="table-title">
        <p>Customer List</p>
      </div>
      <div>
      <Table responsive>
        <thead>
          <tr>
            <th>Name</th>
            <th>Phone</th>
            <th>Address</th>
            <th>Company</th>
            <th>Age</th>
            <th>Email</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {customers.map((customer, index) => (
            <tr key={index}>
              <td>{customer.name}</td>
              <td>{customer.phone}</td>
              <td>
                No.{customer.address.number}, {customer.address.state},{" "}
                {customer.address.street}, {customer.address.city}
              </td>
              <td>{customer.company}</td>
              <td>{customer.age}</td>
              <td>{customer.email}</td>
              <td>
              <button onClick={() => {}} className="logInButton">More Info</button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      </div>
      
    </div>
  );
};

export default CustomerTable;
