import Fetcher from '../lib/fetcher';
import {DnaDatabaseService} from '../lib/constants/endpoints';
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
    const mutationsResponse = await Fetcher.get(DnaDatabaseService.AllMutations);
    const mutations = mutationsResponse.ok
        ? await mutationsResponse.json()
        : mutationsResponse.status;
    dispatch(fetchMutationsSuccess(mutations))
};