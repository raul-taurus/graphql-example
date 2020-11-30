#!/bin/sh
dir=$(dirname $0)
$dir/ts/build.sh
node $dir/app.js
