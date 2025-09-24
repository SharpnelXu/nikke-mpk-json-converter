# Planning

## Context
It is good to have data classes that are human readable, which is why previously the data gathered have `.json` format. However, the data source recently switched to bundle all data using MemoryPack serialization, which caused issues since the program does not have the ability to parse `.mpk` files.

## Goal
The goal of this project is to write a converter that is able to convert MemoryPack serialized data files (`.mpk` files) to Json format (`.json` files).


## Input
- All inputs are located in the `data` folder.
- The files that contains MemoryPack serialized data always have the `.mpk` extension.
- For each `***.mpk` file, there is also a deserialized data file `***.json`, which can be used as references, e.g. `WordTable.mpk` matches `WordTable.json`. 
    - The order of data should match.
    - However, there could be more data in `*.mpk` files.


## Stage 1: Write data model
1. For now, focus on `WordTable.mpk` file in the `data` folder.
2. Open the corresponding reference file, which should be a json object with two fields: `version` and `records`.
3. Ignore the `version` field, as it's not useful. Focus on the `records` field, it should be a list of json objects, and this list is what `WordTable.mpk` file actually serializes.
4. Read the json objects in the `records` list, write the corresponding data model class using MemoryPack, output the data models to `model` folder. The class of this model class can be `Word`, as the input is `WordTable.json`.
5. Make it so the data class created is compatible to both MemoryPack and Json. The json property name should match exactly to what the reference file provides.

## Stage 2: Write serializer to verify data model
1. For certain String fields, the actual field might be an enum, which means the reference file is still needed to figure out the enum mapping. The good news is the order of these data should match.
2. Open the mpk file and read it as hex string, skip the first eight byte since it represents the array length.
3. Write a serialization class that reads and seralizes each record of the reference json file individually.
4. Convert each seralized object to hex string and calculate its length, then take equal length of hex string from the mpk hex string (skiping first 8 bytes) and see if they match.
4. If they don't, that means a string field should be an enum instead. Stop the program and print the hex bytes.

## Stage 3: Write Converter
1. Now the data class is ready, write a program in `converter` folder that deserialize the input, `WordTable.mpk` using the data class added.


## Stage 4: Repeat for other mpk files
1. Execute Step1 for the following files:
    - UnionRaidPresetTable.mpk