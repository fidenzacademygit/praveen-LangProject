import axios from "axios";
import React from "react";
import { useState, useEffect } from "react";
import Table from "react-bootstrap/Table";
import { apiUrl } from "../types/APIHelper";



axios.interceptors.request.use(
  
  (config) => {
    const accessToken = localStorage.getItem("authToken");
    if(accessToken){
      config.headers.authorization = `Bearer ${accessToken}`;
    }else{
      console.log("AccessToken Does Not Here!");
    }
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
