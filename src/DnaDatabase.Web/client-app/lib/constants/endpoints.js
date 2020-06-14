import Settings from '../../../appsettings.json';

const DnaDatabaseService = {
    AllMutations: `${Settings.DnaDatabaseService.URL}/mutations/all`,
    Mutation: `${Settings.DnaDatabaseService.URL}/mutations/{0}`
};

export {
    DnaDatabaseService
};
