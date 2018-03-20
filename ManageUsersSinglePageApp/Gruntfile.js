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
        },

        uglify: {
            my_target: {
                files: { 'app/app-ugly.min.js': ['app/app.js'] }
            }
        },

        watch: {
            scripts: {
                files: ['app/app.js'],
                tasks: ['uglify']
            }
        }
    });

    grunt.registerTask('default', ['copy', 'uglify', 'watch']);
};