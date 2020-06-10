import { createStore, applyMiddleware, compose } from 'redux';
import thunk from 'redux-thunk';
import { persistStore, persistReducer } from 'redux-persist';
import storage from 'redux-persist/lib/storage';
import {
    FETCH_MUTATIONS_SUCCESS,
    FETCH_MUTATIONS_FAILURE,
    FETCHING_MUTATIONS } from './types';

const initialState = {
    dna: [],
    isFetching: false
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case FETCHING_MUTATIONS:
            return {
                ...state,
                isFetching: true
            };
        case FETCH_MUTATIONS_SUCCESS:
            return {
                ...state,
                isFetching: false,
                dna: [...action.payload.mutations]
            };
        case FETCH_MUTATIONS_FAILURE:
            return {
                ...state,
                isFetching: false
            };
        default:
            return state;
    }
};

const persistConfig = {
    key: 'root',
    storage,
    whitelist: []
};

const persistedReducer = persistReducer(persistConfig, reducer);

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

export const store = createStore(
    persistedReducer,
    composeEnhancers(applyMiddleware(thunk))
);

export const persister = persistStore(store);
