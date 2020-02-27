import test from "./test";

export function expensive(time) {
  let start = Date.now(),
    count = 0;
  while (Date.now() - start < time) count++;
  console.log("test");
  return test();
}
