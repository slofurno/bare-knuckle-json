src=BareKnuckleJson
buildDir=bin/release/net45
out=BareKnuckleJson.dll

.PHONY: build45 builddnx all

all: build45 builddnx

builddnx:
	cd $(src); dnu.cmd build --configuration release

build45:
	cd $(src); csc /target:library /out:$(out) Json.cs; mkdir -p $(buildDir); mv $(out) $(buildDir)/$(out) 
