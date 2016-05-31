var gulp = require('gulp'),
    concat = require('gulp-concat'),
    cssmin = require('gulp-cssmin'),
    uglify = require('gulp-uglify');

gulp.task('css', function () {
    gulp.src([
        './SapnaHtml/css/bootstrap.css',
        './SapnaHtml/css/font-awesome.css',
        './SapnaHtml/css/slick.css',
        './SapnaHtml/css/style.css',
        './SapnaHtml/css/form.css'
    ])
    .pipe(concat('frontend.css'))
    .pipe(gulp.dest('./wwwroot/css/'));

    gulp.src([
        './SapnaHtml/Dashboard/css/bootstrap.css',
        './SapnaHtml/Dashboard/css/font-awesome.css',
        './SapnaHtml/Dashboard/css/bootstrap-datepicker3.css',
        './SapnaHtml/Dashboard/css/slick.css',
        './SapnaHtml/Dashboard/css/select2.css',
        './SapnaHtml/Dashboard/css/tagmanager.css',
        './SapnaHtml/Dashboard/css/sb-admin-2.css',
        './SapnaHtml/Dashboard/css/style.css',
        './SapnaHtml/Dashboard/css/form.css'
    ])
    .pipe(concat('backend.css'))
    .pipe(gulp.dest('./wwwroot/css/'));
});

gulp.task('cssmin', function () {
    gulp.src(['./wwwroot/css/frontend.css'])
    .pipe(concat('frontend.min.css'))
    .pipe(cssmin())
    .pipe(gulp.dest('./wwwroot/css/'));

    gulp.src(['./wwwroot/css/backend.css'])
    .pipe(concat('backend.min.css'))
    .pipe(cssmin())
    .pipe(gulp.dest('./wwwroot/css/'));
});

gulp.task('js', function () {
    gulp.src([
        './SapnaHtml/js/jquery.js',
        './SapnaHtml/js/bootstrap.js',
        './SapnaHtml/js/slick.js',
        './SapnaHtml/js/wow.js',
        './SapnaHtml/js/custom.js'
    ])
    .pipe(concat('frontend.js'))
    .pipe(gulp.dest('./wwwroot/js/'));

    gulp.src([
        './SapnaHtml/Dashboard/js/jquery.js',
        './SapnaHtml/Dashboard/js/bootstrap.js',
        './SapnaHtml/Dashboard/js/select2.full.js',
        './SapnaHtml/Dashboard/js/tagmanager.js',
        './SapnaHtml/Dashboard/js/bootstrap-datepicker.js',
        './SapnaHtml/Dashboard/js/custom.js'
    ])
    .pipe(concat('backend.js'))
    .pipe(gulp.dest('./wwwroot/js/'));
});

gulp.task('jsmin', function () {
    gulp.src(['./wwwroot/js/frontend.js'])
    .pipe(concat('frontend.min.js'))
    .pipe(uglify())
    .pipe(gulp.dest('./wwwroot/js/'));

    gulp.src(['./wwwroot/js/backend.js'])
    .pipe(concat('backend.min.js'))
    .pipe(uglify())
    .pipe(gulp.dest('./wwwroot/js/'));
});

gulp.task("copy", () => {
    gulp.src([
        'fonts/**',
        'images/**',
        'css/**',
        'js/**'
    ], { cwd: "SapnaHtml/**" })
    .pipe(gulp.dest("./wwwroot/assets"));
});

gulp.task('default', function () {
    
});