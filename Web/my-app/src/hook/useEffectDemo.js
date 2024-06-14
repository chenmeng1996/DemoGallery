import React, { useEffect, useState } from 'react';

function Example() {
  const [count, setCount] = useState(0);

  // equal componentDidMount and componentDidUpdate:
  useEffect(() => {
    // use API of browser to update page title
    document.title = `You clicked ${count} times`;
  });

  return (
    <div>
      <p>You clicked {count} times</p>
      <button onClick={() => setCount(count + 1)}>
        Click me
      </button>
    </div>
  );
}




export {Example};