/// <vs BeforeBuild='flat' AfterBuild='build' Clean='clean-packages' />
var gulp = require("gulp"),
    replace = require("gulp-replace"),
    exec = require("child_process").exec;

var srcPath = "./src/";

gulp.task("flat", function(cb) {
    exec("flatten-packages", function(err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        cb(err);
    });
});

gulp.task("build", function () {
    gulp.src("./package.json")
        .pipe(gulp.dest("../wpf/bin/x64/Debug/dist/logger/"));

    gulp.src([srcPath + "agilus-logger.js", srcPath + "agilus.udl"])        
        .pipe(gulp.dest("../wpf/bin/x64/Debug/dist/service"));

    gulp.src([srcPath + "install.js", srcPath + "uninstall.js", "./build/logger/agilus.cmd"])
        .pipe(replace(/..\/node_modules\//g, ""))
        .pipe(gulp.dest("../wpf/bin/x64/Debug/dist/logger"));
});