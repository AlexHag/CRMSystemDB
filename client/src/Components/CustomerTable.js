import React, { useState, useEffect } from 'react';

import '../css/customerTable.css';

function CustomerTable()
{
    const [customerData, setCustomerData] = useState([]);

    useEffect(() => {
        const getData = async () => {
            const response = await fetch('http://localhost:5280/Customer');
            const result = await response.json();
            setCustomerData(result);
        }
        getData();
        console.log(customerData);
    }, []);

    return (
        <>
        <table className="customer-table">
            <tr>
                <th className="customer-th">Name:</th>
                <th className="customer-th">Email</th>
                <th className="customer-th">Phone Number:</th>
            </tr>
            {customerData.map(p => (
                <tr>
                    <td className="customer-td">{p.name}</td>
                    <td className="customer-td">{p.email}</td>
                    <td className="customer-td">{p.phoneNumber}</td>
                </tr>
            ))}
        </table>
        </>
    );
}

export default CustomerTable;