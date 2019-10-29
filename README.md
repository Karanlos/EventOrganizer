# Event Organizer

Event REST API designed around Venues, talks and participants.

## Service Overview

* Hosting
  * Designed to run on an Azure Web App
    * Uses .NET Core MVC to expose the endpoints
  * Database Considerations
    * Relational database (Not implemented yet)
* API Documentation
  * Uses Swagger UI to generate an OpenAPI document for easy usage for generating connectors in your programming language of choice
    * Swagger UI enabled to give an overview and provide a simple testing tool for developers considering consuming the API
* Version control
  * Simple versioning used to help create a stable API and help with maintaining the different versions
* API Overview
  * Designed to be able to Create, Update, Delete and Get data regarding the different entities
    * The endpoints handling the entities are meant to be User specific, meaning only they users who owns the Event, talk etc. should be able to access them
    * Admin API for super users, who are able to handle all the entities of the exposed APIs
  * Can query Different Venue databases, providing an overview of which venues that can be used for an event.
* No Unit tests, but should be added to ensure code runs according the the unit specification

## Legal considerations

The service consumes personal data, which should be protected with proper user access and security measures.

### User rights (GDPR)

* Information store regarding the user (Right to Access)
  * The service exposes endpoints sufficient the collect out all information regarding the user, if they so choose
* Control of the information stored regarding the user (Right to Rectification, Right to Erasure)
  * The services provides functionality to update user data, if they user so chooses. Admins are also able to handle this data, if provided with the correct rights.
  * The service provides functionality that deletes data stored regarding the user, if they so choose.
    * Roadmap includes the proof of deletion, returning what data was deleted.
* The service does not take age into consideration
  * Consumers should make sure that users are able to consent to what data they are sending the service
  * Future implementations could segregated different age groups where children should have parental consent.

# Security

## Identity Provider

* Uses Auth0 as a Identity Provider
  * Decentralized login facilitating authorization independent of who ever uses them
  * Uses OpenID Protocol to authorize the user
    * Uses JSON Web Tokens to handle the claims between the service and Auth0
      * Helps create a stateless service, for easier scalability
      * Signed by Auth0 to prove the authenticity of the Token
      * Provides information about the user
        * Unique ID
        * Claims and Permissions
  * The service uses Auth0 to maintain roles of users, to make it easier to give them the right permissions
    * Permissions are enforced through Annotations on the endpoints. Currently not working as expected, fallback created, but missing proper validation
    * Eg. a person giving a Talk should be able to create a talk and associate it with an event, but participants should only be able to register to an event
    * Admins have special roles also divided into different roles depending on what they should administer eg. Events
* Should run with a TLS/SSL enabled connection to ensure traffic sniffers can't hijack tokens
  * This should be enforced by the host provider, in this case Azure