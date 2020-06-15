# DNA-Database
The DNA Database is intended to be an interactive display of DNA mutation data sourced from [splenic marginal zone lymphoma (SMZL) patients](https://www.nature.com/articles/s41598-019-46906-1). Hosting the data in this way will make it easier to interrogate and examine than through simple .csv or Excel documents. The project consists of a React front-end app, a .NET Core API written in C#, and an Azure Cosmos database.

## Setup
The project has not yet been deployed to an Azure web app service. However, it can be run locally. To do so, you must have an instance of the Azure Cosmos DB Emulator running.

There are two projects within the solution:
- `DnaDatabase.Service`: The .NET Core API
- `DnaDatabase.Web`: The React front-end app

Running `dotnet run` on `DnaDatabase.Service` will start the back-end side of the project, and spin-up the Cosmos database ("DnaDatabase") and container ("Mutations"). This will not put any items into the container, so it is advisable that you enter some data first so that the front-end app has something to show. The data should be of the format:

| id  | partitionKey  | Reference  | Mutant  | Gene  | VariantFunction  | AAChange  | DBSNP  |
|---|---|---|---|---|---|---|---|
| int  | string  | string  | string  | string  | enum  | string  | string  |
| The chromosome of the mutation  | Position where variant starts and ends  | Reference allele  | Mutated allele  | Gene name associated with variant  | Variant type, e.g. 'Stopgain'  | Amino acid change  | dbSNP144 with allelic splitting and left-normalization  |

For example, the following entries would be valid:

```json
{
    "id": "1",
    "partitionKey": "2556699:2556699",
    "Reference": "G",
    "Mutant": "A",
    "Gene": "TNFRSF14",
    "VariantFunction": "Stopgain",
    "AAChange": "TNFRSF14:NM_001297605:exon1:c.G35A:p.W12X,TNFRSF14:NM_003820:exon1:c.G35A:p.W12X",
    "DBSNP": "rs768520625"
}
```

```json
{
    "id": "1",
    "partitionKey": "1340274:1340274",
    "Reference": "T",
    "Mutant": "C",
    "Gene": "DVL1",
    "VariantFunction": "NonSynonymousSNV",
    "AAChange": "DVL1:NM_004421:exon7:c.A742G:p.N248D",
    "DBSNP": ""
}
```

To view the data on the front-end, run `dotnet run` on the `DnaDatabase.Web` project, and open a browser to `https://localhost:5001`.
