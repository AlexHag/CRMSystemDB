import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Link, Routes, Route } from "react-router-dom";
import CustomerTable from './Components/CustomerTable';
import './css/customerTable.css'
import Create from './Components/Create';

function App() {
  return (
      <div className="App">
      
      <Link to="/Customers">Customers</Link>
      <Link to="/Create">Create</Link>
      <Routes>
        <Route path="/Customers" element={<CustomerTable />}></Route>
        <Route path="/Create" element={<Create />}></Route>
      </Routes> 
    </div>

  );
}

export default App;
