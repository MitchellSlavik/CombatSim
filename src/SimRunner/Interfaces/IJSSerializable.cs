using WebAssembly;

namespace SimRunner.Interfaces {
  public interface IJSSerializable {
    void FromJSObject(JSObject obj);
  }
}