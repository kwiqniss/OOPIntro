# OOPIntro
Code samples included. [Video demonstration](https://youtu.be/6cQaLeHo4CU)

Errata: 
- colon is the symbol for extends/implements (not semi-colon) 

Also:
- const variables are usually all caps. MESSAGE. If it were multiple words, instead of camelCasing, we'd separate them with an underscore: INSTUCTOR_MESSAGE. Since the runtime isn't available until after the app is compiled, the value assigned to any const must be a literal value. You can't use variables or methods when storing a const. If you need to have the runtime available before you know what should be assigned to the const, then what you're actually looking for is readonly. 

- the Message string uses the @ symbol followed by quotes. This is a multi-line literal. Whitespace, including new lines, are preserved.
