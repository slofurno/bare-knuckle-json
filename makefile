src=BareKnuckleJson
buildDir=bin/release/net45
out=BareKnuckleJson.dll

.PHONY: build45 builddnx all version nuget

all: nuget build45 builddnx

builddnx:
	cd $(src); dnu.cmd build --configuration release

build45:
	cd $(src); csc /target:library /out:$(out) Json.cs; mkdir -p $(buildDir); mv $(out) $(buildDir)/$(out) 	

nuget: build45 builddnx
	@VERSION=$$(cat VERSION); VERSION=`expr $$VERSION + 1`; echo $$VERSION > VERSION; cd $(src); nuget pack BareKnuckleJson.nuspec -Version 0.5.$$VERSION
