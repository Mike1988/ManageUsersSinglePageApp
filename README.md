# ManageUsersSinglePageApp

A small Single Page Application using AngularJS allowing the management of a 'User' model. Curently only supports List, Create and Update.

A few things to note:
1. There is a Gruntfile.js which supports three tasks:
    1. Copy of node_modules to the appropriate solution folders.
    2. Uglify the main app.js file.
    3. Watch for any changes in the app.js file and then execute the "Ugligy" task when these changes occur.
2. There is currenly only one "app.js" file which supports all of the Angular app configuration, controllers and services. These should be split out into their own files in the future.
3. Re-useability can be improved using custom angular directives.
4. The "UserController" should be changed to an "ApiController". Currently experiencing some issues with IoC for the Web Api so it is a normal MVC "Controller" for now.
