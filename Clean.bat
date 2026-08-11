
set  solution=SampleView
set  config="Debug"


msbuild  -restore  -t:Clean     ^
    -p:Configuration=%config%   -p:Platform=x64     ^
    "%solution%.sln"
