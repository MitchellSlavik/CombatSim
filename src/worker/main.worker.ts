const ctx: Worker = self as any;

ctx.onmessage = () => {
  console.log("worker got message");
  postMessage("", "");
};
