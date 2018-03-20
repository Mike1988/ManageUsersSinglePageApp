module.exports = function (grunt) {
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-copy');

    grunt.initConfig({
        copy: {
            main: {
                expand: true,
                src: 'node_modules/angular/angular*.js',
                dest: "Scripts/angular",
                flatten: true
            },
            angular_route: {
                expand: true,
                src: 'node_modules/angular-route/angular-route*.js',
                dest: "Scripts/angular",
                flatten: true
            }
        }

        //uglify: {
        //    my_target: {
        //        files: { 'wwwroot/js/app.js': ['Scripts/app.js', 'Scripts/**/*.js'] }
        //    }
        //},

        //watch: {
        //    scripts: {
        //        files: ['Scripts/**/*.js'],
        //        tasks: ['uglify']
        //    }
        //}
    });

    grunt.registerTask('default', ['copy']);
};