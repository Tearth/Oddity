# Version 2.0.2 (26-07-2020)
 * Fixed a bug with invalid name translation when there was no JsonProperty attribute (thanks martindevans)

# Version 2.0.1 (21-07-2020)
 * Added statistics
 * Fixed a bug with invalid cache population in queries

# Version 2.0.0 (20-07-2020)
 * Total refactoring of the library (a lot of changed endpoints and models)
 * Added support for v4 API version (incompatible backward)
 * Added support for the new query system
 * Added lazy properties to the models
 * Added internal cache for received data

# Version 1.0.13 (03-07-2020)
 * Changed API version to v3
 * Added new endpoints support for history, capsules and cores
 * Added missing fields to the models
 * Fixed models inconsistency

WARNING: this is the last release for v2/v3 API version. The next one will be completely rewritten to support v4 within a month or two - it won't be compatible backward. More info: https://github.com/r-spacex/SpaceX-API/issues/380

# Version 1.0.12 (26-02-2020)
 * Added methods to retrieve information about API
 * Cleaned up code

# Version 1.0.11 (30-07-2019)
 * Removed filters that aren't present in API
 * Fixed potential deadlock when using sync version of methods
 * Fixed a lot of smaller issues

# Version 1.0.10 (05-02-2019)
 * Fixed deserialization errors (thanks martindevans)
 * Removed unused core statuses

# Version 1.0.9 (20-12-2018)
 * Fixed deserialization errors (thanks martindevans)

# Version 1.0.8 (23-09-2018)
 * Added new landing place

# Version 1.0.7 (11-09-2018)
 * Fixed missions property in detailed cores and capsules

# Version 1.0.6 (09-09-2018)
 * Added new orbit type (SO)

# Version 1.0.5 (08-09-2018)
 * Added new orbit type (MEO)
 * Fixed invalid data types in some models which caused deserialization errors

# Version 1.0.4 (24-08-2018)
 * Added a lot of new data to models

# Version 1.0.3 (16-08-2018)
 * Added OnResponseReceive and OnRequestSend events
 * Added Roadster endpoint
 * Fixed exception related with new landing zone (LZ-3)
 * Some minor changes and fixes

# Version 1.0.2 (02-06-2018)
 * Added orbit parameters to the second stage data
 * Removed unused exceptions
 * Fixed missing comments
 * Fixed async issues

# Version 1.0.1 (31-05-2018)
 * Added ability to retrieve data from GetAbout method without explicit WithType or WithSerial call
 * Unified some model property names
 * Replaced all int? types with uint? to be more readable

# Version 1.0.0 (30-05-2018)
 * Initial version