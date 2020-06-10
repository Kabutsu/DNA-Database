import React from 'react';
import {createUseStyles} from 'react-jss';
import { Grid, Paper, Tab, Tabs, Typography } from '@material-ui/core';
import headerStyles from '../styles/header';

const tabs = [
    {
        label: "Variants",
        value: 0
    },
    {
        label: "Coming Soon",
        value: 1
    }
];

const useStyles = createUseStyles(headerStyles);

const Header = ({
    imageUrl,
    tabValue,
    onTabChange
}) => {
    const classes = useStyles();
    return (
        <div className={classes.appHeader}>
            <Grid container spacing={0}>
                <Grid item xs={2}>
                    <img src={imageUrl} className={classes.appLogo} alt="Logo" />
                </Grid>
                <Grid item xs={10}>
                    <Typography
                        className={classes.headerText}
                        variant="h2"
                        component="h1"
                    >
                        SMZL Mutation Database
                    </Typography>
                </Grid>
                <Grid item xs={12}>
                    <Paper>
                        <Tabs
                            value={tabValue}
                            onChange={(event, newValue) => onTabChange(newValue)}
                            variant="fullWidth"
                            indicatorColor="primary"
                            textColor="primary"
                            centered
                        >
                            {tabs.map(tab => (
                                <Tab label={tab.label} value={tab.value} />
                            ))}
                        </Tabs>
                    </Paper>
                </Grid>
            </Grid>
        </div>
    );
};

export default Header;
