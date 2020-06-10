import {
    FETCH_MUTATIONS_SUCCESS,
    FETCH_MUTATIONS_FAILURE,
    FETCHING_MUTATIONS } from './types';

export const fetchMutationsSuccess = (mutations) => ({
    type: FETCH_MUTATIONS_SUCCESS,
    payload: {mutations}
});

export const fetchMutationsFailure = (error) => ({
    type: FETCH_MUTATIONS_FAILURE,
    payload: {error}
});

export const fetchMutations = () => async (dispatch, getState) => {
    dispatch({ type: FETCHING_MUTATIONS });
    const mutations = [
        {
            mutation: 'smzl'
        },
        {
            mutation: 'sonic'
        }
    ];
    dispatch(fetchMutationsSuccess(mutations))
};