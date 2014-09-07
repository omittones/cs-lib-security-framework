Security framework example
==========================

A framework for checking user permissions on actions that can be performed on 
domain objects (Invoice and InvoiceItem).

If the the action for domain object is allowed for that user, a placeholder 
which invokes the action is rendered (HTML button).

If the action is not allowed, a placeholder which only describes the action, but 
does not invoke it is rendered instead (HTML span).

Type safe actions on domain objects are defined via interfaces (*Domain/Actions* 
folder).

Security checks implement action interfaces (*Domain/Security* folder).

UI placeholder factories also implement action interfaces (*UI* folder).

The framework uses delegate as a method selector (*a -> a.Update*). Method 
selector is used on security checker to check if the action is allowed and again
on the UI placeholder factory to to render proper placeholder (action allowed 
or forbidden).