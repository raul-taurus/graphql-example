#!/bin/sh
dir=$(dirname $0)
echo $dir
tsc --outDir $dir/../ $dir/main.ts
