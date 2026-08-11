
set  solution=SampleView
set  config="Release"


msbuild  -restore  -t:Clean     ^
    -p:Configuration=%config%   -p:Platform=x64     ^
    "%solution%.sln"
