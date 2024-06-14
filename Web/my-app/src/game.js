import './game.css';

import React from 'react';

// function component, it is a simplify syntactic sugar of react component
function Square(props) {
    return (
      <button className="square" onClick={props.onClick}>
        {props.value}
      </button>
    );
  }

class Board extends React.Component {
    renderSquare(i) {
        // transfer corresponding value and button click logic to each Square
        return (
            <Square
            value={this.props.squares[i]}
            onClick={() => this.props.onClick(i)}
            />
        );
    }
    render() {

        return (
            <div>
                {/* <div className="status">{status}</div> */}
                <div className="board-row">
                    {this.renderSquare(0)}
                    {this.renderSquare(1)}
                    {this.renderSquare(2)}
                </div>
                <div className="board-row">
                    {this.renderSquare(3)}
                    {this.renderSquare(4)}
                    {this.renderSquare(5)}
                </div>
                <div className="board-row">
                    {this.renderSquare(6)}
                    {this.renderSquare(7)}
                    {this.renderSquare(8)}
                </div>
            </div>
        );
    }
}

class Game extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            // a snapshot of squares after every move
            history: [
                // initial squares
                {
                    squares: Array(9).fill(null),
                }
            ],
            // next player
            xIsNext: true,
            stepNumber: 0,
        };
    }

    // button click logic
    // Note: When function is used as callback to pass to child component,
    // `this` will be child class intead of current class,
    // At this time must bind `this` in this function.
    handleClick(i) {
        const history = this.state.history.slice(0, this.state.stepNumber + 1);
        const current = history[history.length - 1];
        const current_copy = current.squares.slice(); // a array copy
        
        if (calculateWinner(current_copy) || current_copy[i]) {
            return;
        }
        current_copy[i] = this.state.xIsNext ? 'X' : 'O';
        // add current squares as a snapshort and switch next player
        this.setState({
            history: history.concat([{
                squares: current_copy,
            }]),
            xIsNext: !this.state.xIsNext,
            stepNumber: history.length,
        });
    }

    jumpTo(step) {
        this.setState({
            stepNumber: step,
            xIsNext: (step % 2) === 0,
        });
    }
    
    render() {
        const history = this.state.history;
        const current = history[this.state.stepNumber];
        const winner = calculateWinner(current.squares);
        // step is the value of current item, move is the reference of current item.
        const moves = history.map((step, move) => {
            const desc = move ?
            'Go to move #' + move :
            'Go to game start';
            return (
                <li key={move}>
                    <button onClick={() => this.jumpTo(move)}>{desc}</button>
                </li>
            )
        })
        let status;
        if (winner) {
            status = 'Winner: ' + winner;
        } else {
            status = 'Next player: ' + (this.state.xIsNext ? 'X' : 'O');
        }
        return (
            <div className="game">
                <div className="game-board">
                    {/* transfer current squares and button click logic to Board */}
                    <Board 
                        squares={current.squares}
                        // This syntax create a new callback, so `handleClick` is not a callback. 
                        // So binding `this` is not needed.
                        // But this way may has performance problem because of extra render.
                        onClick={(i) => this.handleClick(i)}
                    />
                </div>
                <div className="game-info">
                    <div>{ status }</div>
                    <ol>{ moves }</ol>
                </div>
            </div>
        );
    }
}

function calculateWinner(squares) {
    const lines = [
      [0, 1, 2],
      [3, 4, 5],
      [6, 7, 8],
      [0, 3, 6],
      [1, 4, 7],
      [2, 5, 8],
      [0, 4, 8],
      [2, 4, 6],
    ];
    for (let i = 0; i < lines.length; i++) {
      const [a, b, c] = lines[i];
      if (squares[a] && squares[a] === squares[b] && squares[a] === squares[c]) {
        return squares[a];
      }
    }
    return null;
}

export {Game};