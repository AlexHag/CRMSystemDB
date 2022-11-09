import '../css/form.css';
import {useState} from 'react';

function Create() {
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");

    const submit = (event) => {
        event.preventDefault();
        console.log(name, email, phoneNumber);
        const requestOptions = {
        method: 'POST',
        headers: { 'Accept': 'application/json',
                    'Content-Type': 'application/json' },
        body: JSON.stringify({name: name, email: email, phoneNumber: phoneNumber})
        };
        
        fetch(`http://localhost:5280/create`, requestOptions);
    }
    return (
        <>
            <div className="form">
            <form>
                <input
                id="txtTodoItemToAdd"
                type="text"
                value={name}
                onChange={(e) => setName(e.target.value)}
                placeholder="Name"
                />
                
                <input
                type="text"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                placeholder="Email"
                />

                <input
                type="text"
                value={phoneNumber}
                onChange={(e) => setPhoneNumber(e.target.value)}
                placeholder="Phone Number"
                />
                
                <button className="add" onClick={submit} id="btnAddTodo">Add</button>
            </form>
            </div>
        </>
    )
}

export default Create;