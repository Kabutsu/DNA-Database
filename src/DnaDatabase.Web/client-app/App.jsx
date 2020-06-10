import React, {useState} from 'react';
import {createUseStyles} from 'react-jss';
import Header from './components/Header';
import Body from './components/Body';
import MutationsTable from './components/MutationsTable';
import appStyles from './styles/app';

const logo = 'assets/logo512.png';
const useStyles = createUseStyles(appStyles);

const App = () => {
  const classes = useStyles();
  const [tabValue, setTabValue] = useState(0);
  return (
    <div className={classes.app}>
      <Header
        imageUrl={logo}
        tabValue={tabValue}
        onTabChange={(value) => setTabValue(value)}
      />
      <Body value={tabValue} index={0}>
        <MutationsTable />
      </Body>
      <Body value={tabValue} index={1}>
        <a
          className={classes.appLink}
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </Body>
    </div>
  );
}

export default App;
