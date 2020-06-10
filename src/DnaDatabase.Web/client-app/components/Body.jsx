import React from 'react';
import {createUseStyles} from 'react-jss';
import bodyStyles from '../styles/body';

const useStyles = createUseStyles(bodyStyles);

const Body = ({
    children, value, index
}) => {
    const styles = useStyles();
    return (
        <div className={styles.root}>
            {value === index && children}
        </div>
    );
};

export default Body;
