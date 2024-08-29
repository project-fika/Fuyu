# Database

## Tables

In order to work well multi-threaded, the following principles are followed:

- NEVER modify data directly; always use the get-set function
- NEVER use properties; they only cover the direct object, not fields within
  the property's instance.
- Many can read (not mutex locked) / single can write (mutex locked).
