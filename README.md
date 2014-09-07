cs-lib-security-framework
=========================

Security framework example

A framework for checking user permissions for actions that can be performed on 
domain objects.
If the the action for domain object is allowed for that user, a placeholder 
which invokes the action is rendered.
If the action is not allowed, a placeholder which only describes the action, but 
does not invoke it is placed instead.

Type safe actions on domain objects are defined via interfaces (Domain/Actions folder).

Security checks implement action interfaces (Domain/Security folder).

UI placeholder factories also implement action interfaces (UI folder).

The framework uses method selector (e.g. a -> a.Update) to invoke proper security
check method, and based on result render proper placeholder based on selected format.