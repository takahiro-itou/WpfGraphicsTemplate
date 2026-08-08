
msbuild  -restore  -t:Clean      ^
    -p:Configuration="Release"  -p:Platform=x64     ^
    SampleView.sln

msbuild  -restore  -t:Rebuild   ^
    -p:Configuration="Release"  -p:Platform=x64     ^
    SampleView.sln
