csc -target:library -out:build/DnDSimRunner.dll -noconfig -nostdlib -r:$WASM_SDK/wasm-bcl/wasm/mscorlib.dll -r:$WASM_SDK/wasm-bcl/wasm/System.dll -r:$WASM_SDK/wasm-bcl/wasm/System.Core.dll -r:$WASM_SDK/wasm-bcl/wasm/Facades/netstandard.dll -r:$WASM_SDK/wasm-bcl/wasm/System.Net.Http.dll -r:$WASM_SDK/framework/WebAssembly.Bindings.dll -r:$WASM_SDK/framework/WebAssembly.Net.Http.dll \
src/simRunner/interfaces/IJSSerializable.cs \
src/simRunner/entities/Creature.cs \
src/simRunner/SimRunner.cs

mono $WASM_SDK/packager.exe --copy=ifnewer --out=./public ./build/DnDSimRunner.dll | grep -v "^cp" -