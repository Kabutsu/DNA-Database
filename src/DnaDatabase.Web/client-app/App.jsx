import React from 'react';
import {createUseStyles} from 'react-jss';
import './styles/App.scss';

const logo = './styles/logo.svg;'
const useStyles = createUseStyles({
  App: {
    textAlign: 'center'
  },
  AppLogo: {
    height: '40vmin',
    pointerEvents: 'none'
  },
  AppHeader: {
    backgroundColor: '#282c34',
    minHeight: '100vh',
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
    justifyContent: 'center',
    fontSize: 'calc(10px + 2vmin)',
    color: 'white',
  }
});

function App() {
  const classes = useStyles();
  return (
    <div className={classes.App}>
      <header className={classes.AppLogo}>
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Hello, world!
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
