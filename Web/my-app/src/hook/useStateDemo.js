import React, { useState } from 'react';

function Example() {
    // declare a state variable named count.
    // use 'useState' hook to add some state into this function component.
    // This hook will return a state and a function to update this state.
    const [count, setCount] = useState(0);
    // you can declare many state variable
    const [age, setAge] = useState(26);
    

    return (
        <div>
            <p>You clicked {count} times</p>
            <button onClick={() => setCount(count + 1)}>
                Click me
            </button>
        </div>
    );
}