var gulp = require('gulp');
var browserSync = require('browser-sync');
var reload = browserSync.reload;


gulp.task('browser-sync', function () {
    browserSync({
        server: {
            baseDir: "./"
        },
        files: [
            "Client/app/**/*.css",
            "Client/app/**/*.html"
        ],
        ghostMode: {
            clicks: true,
            location: true,
            scroll: true,
            forms: true
        }
	});
});