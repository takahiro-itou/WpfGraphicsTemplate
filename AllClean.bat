
msbuild  -t:Clean   ^
    -p:Configuration="Release"  -p:Platform=x64     ^
    SampleView.sln

msbuild  -t:Clean   ^
    -p:Configuration="Debug"    -p:Platform=x64     ^
    SampleView.sln

msbuild  -t:Clean   ^
    -p:Configuration="Release"  -p:Platform=x86     ^
    SampleView.sln

msbuild  -t:Clean   ^
    -p:Configuration="Debug"    -p:Platform=x86     ^
    SampleView.sln


msbuild  -t:Clean   ^
    -p:Configuration="Release"  -p:Platform=x64     ^
    SampleView.NetOld.sln

msbuild  -t:Clean   ^
    -p:Configuration="Debug"    -p:Platform=x64     ^
    SampleView.NetOld.sln

msbuild  -t:Clean   ^
    -p:Configuration="Release"  -p:Platform=x86     ^
    SampleView.NetOld.sln

msbuild  -t:Clean   ^
    -p:Configuration="Debug"    -p:Platform=x86     ^
    SampleView.NetOld.sln
