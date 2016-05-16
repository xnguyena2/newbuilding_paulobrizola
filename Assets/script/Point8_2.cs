using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class Point8_2
{
	public static Vector3 stair = new Vector3 (0.78f, 1.5F, -0.63f);//27.32,-0.1374998,-3.57

	static Vector3 upStair = new Vector3 (6.31f, 1.5f, 24.99f);
	
	public static Vector3 evalator = new Vector3 (6.51F, 1.0F, 2.02f);

	static Vector3 o1 = new Vector3 (15.98001F, 1.5F, -13.97F);
	static Vector3 o2 = new Vector3 (8.140015F, 1.5F, -16.14999F);
	static Vector3 o3 = new Vector3 (8.140015F, 1.5F, -13.77F);
	static Vector3 o4 = new Vector3 (8.140015F, 1.5F, -11.39F);
	static Vector3 o5 = new Vector3 (8.140015F, 1.5F, -8.759995F);
	static Vector3 o6 = new Vector3 (18.32001F, 1.5F, -3.850006F);
	static Vector3 o7 = new Vector3 (19.94F, 1.5F, 0.3099976F);
	static Vector3 o8 = new Vector3 (19.94F, 1.5F, 4.710007F);
	static Vector3 o9 = new Vector3 (19.94F, 1.5F, 9.559998F);
	static Vector3 o10 = new Vector3 (19.94F, 1.5F, 12.75999F);
	static Vector3 o11 = new Vector3 (19.94F, 1.5F, 15.06F);
	static Vector3 o12 = new Vector3 (19.94F, 1.5F, 17.14999F);
	static Vector3 o13 = new Vector3 (19.94F, 1.5F, 19.41F);
	static Vector3 o14 = new Vector3 (19.94F, 1.5F, 21.59F);
	static Vector3 o15 = new Vector3 (19.94F, 1.5F, 23.81F);
	static Vector3 o16 = new Vector3 (19.94F, 1.5F, 26.14999F);
	static Vector3 o17 = new Vector3 (20.10001F, 1.5F, 29.36F);
	static Vector3 o18 = new Vector3 (18.69F, 1.5F, 31.98F);
	static Vector3 o19 = new Vector3 (15.60999F, 1.5F, 31.98F);
	static Vector3 o20 = new Vector3 (13.06F, 1.5F, 31.98F);
	static Vector3 o21 = new Vector3 (10.72F, 1.5F, 31.98F);
	static Vector3 o22 = new Vector3 (8.380005F, 1.5F, 31.98F);
	static Vector3 o23 = new Vector3 (5.75F, 1.5F, 31.98F);
	static Vector3 o24 = new Vector3 (2.5F, 1.5F, 31.98F);
	static Vector3 o25 = new Vector3 (-0.2900085F, 1.5F, 31.98F);
	static Vector3 o26 = new Vector3 (-2.100006F, 1.5F, 31.98F);
	static Vector3 o27 = new Vector3 (-4.359985F, 1.5F, 31.98F);
	static Vector3 o28 = new Vector3 (-8.140015F, 1.5F, 31.98F);
	static Vector3 o29 = new Vector3 (-10.84F, 1.5F, 29.42F);
	static Vector3 o30 = new Vector3 (-11.92999F, 1.5F, 26F);
	static Vector3 o31 = new Vector3 (-11.92999F, 1.5F, 23.53F);
	static Vector3 o32 = new Vector3 (-11.92999F, 1.5F, 21.27F);
	static Vector3 o33 = new Vector3 (-15.23999F, 1.5F, 17.88F);
	static Vector3 o34 = new Vector3 (12.48999F, 1.5F, 18.73F);
	static Vector3 o35 = new Vector3 (9.859985F, 1.5F, 18.73F);
	static Vector3 o36 = new Vector3 (6.480011F, 1.5F, 18.73F);
	static Vector3 o37 = new Vector3 (3.290009F, 1.5F, 18.73F);
	static Vector3 o38 = new Vector3 (1.170013F, 1.5F, 19.94F);
	static Vector3 o39 = new Vector3 (-0.4299927F, 1.5F, 20.08F);
	static Vector3 o40 = new Vector3 (0.9599915F, 1.5F, 14.60001F);
	static Vector3 o41 = new Vector3 (-0.75F, 1.5F, 10.64999F);
	static Vector3 o42 = new Vector3 (-0.75F, 1.5F, 5.070007F);
	static Vector3 o43 = new Vector3 (6.100006F, 1.5F, 3.419998F);
	static Vector3 o44 = new Vector3 (9.119995F, 1.5F, 0.25F);
	static Vector3 o45 = new Vector3 (12.07001F, 1.5F, 0.2700043F);
	static Vector3 o46 = new Vector3 (12.07001F, 1.5F, 3.639999F);
	static Vector3 o47 = new Vector3 (9.200012F, 1.5F, 6.339996F);
	static Vector3 o48 = new Vector3 (9.200012F, 1.5F, 9.240005F);
	static Vector3 o49 = new Vector3 (9.200012F, 1.5F, 11.96001F);
	static Vector3 o50 = new Vector3 (9.200012F, 1.5F, 14.67999F);
	static Vector3 o51 = new Vector3 (2.670013F, 1.5F, -6.940002F);
	static Vector3 o52 = new Vector3 (-0.6499939F, 1.5F, -8.009995F);
	static Vector3 o53 = new Vector3 (-3.619995F, 1.5F, -7.970001F);
	static Vector3 o54 = new Vector3 (-2.140015F, 1.5F, -12.34F);
	static Vector3 o55 = new Vector3 (2.529999F, 1.5F, -12.42999F);
	static Vector3 o56 = new Vector3 (2.529999F, 1.5F, -9.630005F);
	static Vector3 o57 = new Vector3 (-9.540009F, 1.5F, 12.06F);
	static Vector3 o58 = new Vector3 (-12.31F, 1.5F, 11.17999F);
	static Vector3 o59 = new Vector3 (-14.67001F, 1.5F, 11.17999F);
	static Vector3 o60 = new Vector3 (-17.95001F, 1.5F, 11.17999F);
	static Vector3 o61 = new Vector3 (-17.95001F, 1.5F, 6.419998F);
	static Vector3 o62 = new Vector3 (-14.67001F, 1.5F, 6.419998F);
	static Vector3 o63 = new Vector3 (-12.31F, 1.5F, 6.419998F);
	static Vector3 o64 = new Vector3 (-9.48999F, 1.5F, 6.419998F);
	static Vector3 o65 = new Vector3 (-9.48999F, 1.5F, 9.279999F);
	static Vector3 o66 = new Vector3 (-9.119995F, 1.5F, -0.9400024F);
	static Vector3 o67 = new Vector3 (-11.39001F, 1.5F, -0.9400024F);
	static Vector3 o68 = new Vector3 (-13.64999F, 1.5F, -0.9400024F);
	static Vector3 o69 = new Vector3 (-17.31F, 1.5F, 0.4700012F);
	static Vector3 o70 = new Vector3 (-22.07001F, 1.5F, 0.5399933F);
	static Vector3 o71 = new Vector3 (-11.35999F, 1.5F, -6.009995F);
	static Vector3 o72 = new Vector3 (-20.26001F, 1.5F, -9.339996F);
	static Vector3 o73 = new Vector3 (-11.54999F, 1.5F, -12.48F);
	static Vector3 o74 = new Vector3 (-5.609985F, 1.5F, -17.07001F);
	static Vector3 o75 = new Vector3 (4.76001F, 1.5F, -20.57001F);
	static Vector3 o76 = new Vector3 (6.380005F, 1.5F, -20.98F);
	static Vector3 o77 = new Vector3 (8.920013F, 1.5F, -21.66F);
	static Vector3 o78 = new Vector3 (-2.329987F, 1.5F, -17.89F);
	static Vector3 o79 = new Vector3 (20.88F, 1.5F, -3.910004F);
	
	static Vector3 f1 = new Vector3 (16.01001F, 1.5F, -6.289993F);
	static Vector3 f2 = new Vector3 (5.579987F, 1.5F, -16.12F);
	static Vector3 f3 = new Vector3 (5.579987F, 1.5F, -13.78F);
	static Vector3 f4 = new Vector3 (5.579987F, 1.5F, -11.59F);
	static Vector3 f5 = new Vector3 (5.579987F, 1.5F, -9.070007F);
	static Vector3 f6 = new Vector3 (15.54001F, 1.5F, -3.699997F);
	static Vector3 f7 = new Vector3 (15.54001F, 1.5F, 0.2599945F);
	static Vector3 f8 = new Vector3 (15.54001F, 1.5F, 4.789993F);
	static Vector3 f9 = new Vector3 (15.54001F, 1.5F, 9.360001F);
	static Vector3 f10 = new Vector3 (15.54001F, 1.5F, 12.81F);
	static Vector3 f11 = new Vector3 (15.54001F, 1.5F, 15.22F);
	static Vector3 f12 = new Vector3 (15.54001F, 1.5F, 17.2F);
	static Vector3 f13 = new Vector3 (15.54001F, 1.5F, 19.36F);
	static Vector3 f14 = new Vector3 (15.54001F, 1.5F, 21.55F);
	static Vector3 f15 = new Vector3 (15.54001F, 1.5F, 23.67F);
	static Vector3 f16 = new Vector3 (15.54001F, 1.5F, 25.89999F);
	static Vector3 f17 = new Vector3 (16.32001F, 1.5F, 27.09F);
	static Vector3 f18 = new Vector3 (16.04001F, 1.5F, 27.13F);
	static Vector3 f19 = new Vector3 (15.10999F, 1.5F, 26.69F);
	static Vector3 f20 = new Vector3 (13.10001F, 1.5F, 24.64F);
	static Vector3 f21 = new Vector3 (10.72F, 1.5F, 24.64F);
	static Vector3 f22 = new Vector3 (8.420013F, 1.5F, 24.64F);
	static Vector3 f23 = new Vector3 (5.790009F, 1.5F, 24.64F);
	static Vector3 f24 = new Vector3 (2.480011F, 1.5F, 24.64F);
	static Vector3 f25 = new Vector3 (-0.2900085F, 1.5F, 24.64F);
	static Vector3 f26 = new Vector3 (-2.089996F, 1.5F, 24.64F);
	static Vector3 f27 = new Vector3 (-4.209991F, 1.5F, 26.54001F);
	static Vector3 f28 = new Vector3 (-6.829987F, 1.5F, 26.54001F);
	static Vector3 f29 = new Vector3 (-6.690002F, 1.5F, 27.33F);
	static Vector3 f30 = new Vector3 (-6.5F, 1.5F, 25.86F);
	static Vector3 f31 = new Vector3 (-6.5F, 1.5F, 23.74001F);
	static Vector3 f32 = new Vector3 (-6.5F, 1.5F, 21.58F);
	static Vector3 f33 = new Vector3 (-15.48999F, 1.5F, 14.7F);
	static Vector3 f34 = new Vector3 (12.69F, 1.5F, 24.64F);
	static Vector3 f35 = new Vector3 (9.799988F, 1.5F, 24.64F);
	static Vector3 f36 = new Vector3 (6.519989F, 1.5F, 24.64F);
	static Vector3 f37 = new Vector3 (3.190002F, 1.5F, 24.64F);
	static Vector3 f38 = new Vector3 (1.329987F, 1.5F, 24.64F);
	static Vector3 f39 = new Vector3 (-3.160004F, 1.5F, 20.64999F);
	static Vector3 f40 = new Vector3 (-6.450012F, 1.5F, 14.75999F);
	static Vector3 f41 = new Vector3 (-6.450012F, 1.5F, 10.59F);
	static Vector3 f42 = new Vector3 (-6.450012F, 1.5F, 5.550003F);
	static Vector3 f43 = new Vector3 (5.709991F, 1.5F, 0.03999329F);
	static Vector3 f44 = new Vector3 (5.709991F, 1.5F, 0.03999329F);
	static Vector3 f45 = new Vector3 (12.39001F, 1.5F, -4.770004F);
	static Vector3 f46 = new Vector3 (15.62F, 1.5F, 3.589996F);
	static Vector3 f47 = new Vector3 (15.62F, 1.5F, 6.380005F);
	static Vector3 f48 = new Vector3 (15.62F, 1.5F, 9.270004F);
	static Vector3 f49 = new Vector3 (15.62F, 1.5F, 12.00999F);
	static Vector3 f50 = new Vector3 (15.62F, 1.5F, 14.7F);
	static Vector3 f51 = new Vector3 (2.690002F, 1.5F, -3.369995F);
	static Vector3 f52 = new Vector3 (-0.4100037F, 1.5F, -3.369995F);
	static Vector3 f53 = new Vector3 (-3.619995F, 1.5F, -3.369995F);
	static Vector3 f54 = new Vector3 (-6.619995F, 1.5F, -12.58F);
	static Vector3 f55 = new Vector3 (5.559998F, 1.5F, -12.41F);
	static Vector3 f56 = new Vector3 (5.660004F, 1.5F, -9.630005F);
	static Vector3 f57 = new Vector3 (-6.480011F, 1.5F, 12.25999F);
	static Vector3 f58 = new Vector3 (-12.20999F, 1.5F, 14.69F);
	static Vector3 f59 = new Vector3 (-14.72F, 1.5F, 14.69F);
	static Vector3 f60 = new Vector3 (-17.17999F, 1.5F, 14.69F);
	static Vector3 f61 = new Vector3 (-17.88F, 1.5F, 3.360001F);
	static Vector3 f62 = new Vector3 (-14.73001F, 1.5F, 3.360001F);
	static Vector3 f63 = new Vector3 (-12.38F, 1.5F, 3.360001F);
	static Vector3 f64 = new Vector3 (-6.679993F, 1.5F, 6.009995F);
	static Vector3 f65 = new Vector3 (-6.540009F, 1.5F, 9.320007F);
	static Vector3 f66 = new Vector3 (-6.540009F, 1.5F, -1.039993F);
	static Vector3 f67 = new Vector3 (-11.32001F, 1.5F, 3.149994F);
	static Vector3 f68 = new Vector3 (-13.56F, 1.5F, 3.149994F);
	static Vector3 f69 = new Vector3 (-17.29999F, 1.5F, 3.149994F);
	static Vector3 f70 = new Vector3 (-21.79001F, 1.5F, 3.149994F);
	static Vector3 f71 = new Vector3 (-6.51001F, 1.5F, -6.009995F);
	static Vector3 f72 = new Vector3 (-6.51001F, 1.5F, -9.270004F);
	static Vector3 f73 = new Vector3 (-6.51001F, 1.5F, -13.02F);
	static Vector3 f74 = new Vector3 (-4.950012F, 1.5F, -14.78F);
	static Vector3 f75 = new Vector3 (5.480011F, 1.5F, -17.92999F);
	static Vector3 f76 = new Vector3 (6.929993F, 1.5F, -18.62F);
	static Vector3 f77 = new Vector3 (8.589996F, 1.5F, -19.04001F);
	static Vector3 f78 = new Vector3 (-1.970001F, 1.5F, -15.39F);
	static Vector3 f79 = new Vector3 (20.88F, 1.5F, -6.460007F);
	
	static Vector3 p1 = new Vector3 (0.7799988F, 1.5F, -3.929993F);
	static Vector3 p2 = new Vector3 (5.609985F, 1.5F, -3.929993F);
	static Vector3 p3 = new Vector3 (15.5F, 1.5F, -3.929993F);
	static Vector3 p4 = new Vector3 (15.5F, 1.5F, 24.64F);
	static Vector3 p5 = new Vector3 (-6.269989F, 1.5F, 24.64F);
	static Vector3 p6 = new Vector3 (5.540009F, 1.5F, -15.03999F);
	static Vector3 p7 = new Vector3 (5.540009F, 1.5F, -17.92999F);
	static Vector3 p8 = new Vector3 (-6.519989F, 1.5F, -4.139999F);
	static Vector3 p9 = new Vector3 (-6.519989F, 1.5F, -14.17999F);
	static Vector3 p10 = new Vector3 (-6.519989F, 1.5F, 3.429993F);
	static Vector3 p11 = new Vector3 (-6.519989F, 1.5F, 14.89999F);
	static Vector3 p12 = new Vector3 (-6.519989F, 1.5F, 20.47F);
	static Vector3 p13 = new Vector3 (-6.519989F, 1.5F, -0.8899994F);
	static Vector3 p14 = new Vector3 (5.559998F, 1.5F, -6.460007F);

	
	static Vector3[] office1 = new Vector3[] { stair, p1, p3, f1, o1 };
	static Vector3[] office2 = new Vector3[] { stair, p1, p2, f2, o2 };
	static Vector3[] office3 = new Vector3[] { stair, p1, p2, f3, o3 };
	static Vector3[] office4 = new Vector3[] { stair, p1, p2, f4, o4 };
	static Vector3[] office5 = new Vector3[] { stair, p1, p2, f5, o5 };
	static Vector3[] office6 = new Vector3[] { stair, p1, p3, f6, o6 };
	static Vector3[] office7 = new Vector3[] { stair, p1, p3, f7, o7 };
	static Vector3[] office8 = new Vector3[] { stair, p1, p3, f8, o8 };
	static Vector3[] office9 = new Vector3[] { stair, p1, p3, f9, o9 };
	static Vector3[] office10 = new Vector3[] { stair, p1, p3, f10, o10 };
	static Vector3[] office11 = new Vector3[] { stair, p1, p3, f11, o11 };
	static Vector3[] office12 = new Vector3[] { stair, p1, p3, f12, o12 };
	static Vector3[] office13 = new Vector3[] { stair, p1, p3, f13, o13 };
	static Vector3[] office14 = new Vector3[] { stair, p1, p3, f14, o14 };
	static Vector3[] office15 = new Vector3[] { stair, p1, p3, f15, o15 };
	static Vector3[] office16 = new Vector3[] { stair, p1, p3, p4, f16, o16 };
	static Vector3[] office17 = new Vector3[] { stair, p1, p3, p4, f17, o17 };
	static Vector3[] office18 = new Vector3[] { stair, p1, p3, p4, f18, o18 };
	static Vector3[] office19 = new Vector3[] { stair, p1, p3, p4, f19, o19 };
	static Vector3[] office20 = new Vector3[] { stair, p13, p5, f20, o20 };
	static Vector3[] office21 = new Vector3[] { stair, p13, p5, f21, o21 };
	static Vector3[] office22 = new Vector3[] { stair, p13, p5, f22, o22 };
	static Vector3[] office23 = new Vector3[] { stair, p13, p5, f23, o23 };
	static Vector3[] office24 = new Vector3[] { stair, p13, p5, f24, o24 };
	static Vector3[] office25 = new Vector3[] { stair, p13, p5, f25, o25 };
	static Vector3[] office26 = new Vector3[] { stair, p13, p5, f26, o26 };
	static Vector3[] office27 = new Vector3[] { stair, p13, p5, f27, o27 };
	static Vector3[] office28 = new Vector3[] { stair, p13, p5, f28, o28 };
	static Vector3[] office29 = new Vector3[] { stair, p13, p5, f29, o29 };
	static Vector3[] office30 = new Vector3[] { stair, p13, p5, f30, o30 };
	static Vector3[] office31 = new Vector3[] { stair, p13, f31, o31 };
	static Vector3[] office32 = new Vector3[] { stair, p13, f32, o32 };
	static Vector3[] office33 = new Vector3[] { stair, p13, p11, f33, o33 };
	static Vector3[] office34 = new Vector3[] { stair, p1, p3, p4, f34, o34 };
	static Vector3[] office35 = new Vector3[] { stair, p13, p5, f35, o35 };
	static Vector3[] office36 = new Vector3[] { stair, p13, p5, f36, o36 };
	static Vector3[] office37 = new Vector3[] { stair, p13, p5, f37, o37 };
	static Vector3[] office38 = new Vector3[] { stair, p13, p5, f38, o38 };
	static Vector3[] office39 = new Vector3[] { stair, p13, p12, f39, o39 };
	static Vector3[] office40 = new Vector3[] { stair, p13, p11, f40, o40 };
	static Vector3[] office41 = new Vector3[] { stair, p13, f41, o41 };
	static Vector3[] office42 = new Vector3[] { stair, p13, f42, o42 };
	static Vector3[] office43 = new Vector3[] { stair, f43, o43 };
	static Vector3[] office44 = new Vector3[] { stair, f44, o44 };
	static Vector3[] office45 = new Vector3[] { stair, p1, f45, o45 };
	static Vector3[] office46 = new Vector3[] { stair, p1, p3, f46, o46 };
	static Vector3[] office47 = new Vector3[] { stair, p1, p3, f47, o47 };
	static Vector3[] office48 = new Vector3[] { stair, p1, p3, f48, o48 };
	static Vector3[] office49 = new Vector3[] { stair, p1, p3, f49, o49 };
	static Vector3[] office50 = new Vector3[] { stair, p1, p3, f50, o50 };
	static Vector3[] office51 = new Vector3[] { stair, p1, f51, o51 };
	static Vector3[] office52 = new Vector3[] { stair, p1, f52, o52 };
	static Vector3[] office53 = new Vector3[] { stair, p1, f53, o53 };
	static Vector3[] office54 = new Vector3[] { stair, p1, p8, f54, o54 };
	static Vector3[] office55 = new Vector3[] { stair, p1, p2, f55, o55 };
	static Vector3[] office56 = new Vector3[] { stair, p1, p2, f56, o56 };
	static Vector3[] office57 = new Vector3[] { stair, p13, f57, o57 };
	static Vector3[] office58 = new Vector3[] { stair, p13, p11, f58, o58 };
	static Vector3[] office59 = new Vector3[] { stair, p13, p11, f59, o59 };
	static Vector3[] office60 = new Vector3[] { stair, p13, p11, f60, o60 };
	static Vector3[] office61 = new Vector3[] { stair, p13, p10, f61, o61 };
	static Vector3[] office62 = new Vector3[] { stair, p13, p10, f62, o62 };
	static Vector3[] office63 = new Vector3[] { stair, p13, p10, f63, o63 };
	static Vector3[] office64 = new Vector3[] { stair, p13, f64, o64 };
	static Vector3[] office65 = new Vector3[] { stair, p13, f65, o65 };
	static Vector3[] office66 = new Vector3[] { stair, p13, f66, o66 };
	static Vector3[] office67 = new Vector3[] { stair, p13, p10, f67, o67 };
	static Vector3[] office68 = new Vector3[] { stair, p13, p10, f68, o68 };
	static Vector3[] office69 = new Vector3[] { stair, p13, p10, f69, o69 };
	static Vector3[] office70 = new Vector3[] { stair, p13, p10, f70, o70 };
	static Vector3[] office71 = new Vector3[] { stair, p13, f71, o71 };
	static Vector3[] office72 = new Vector3[] { stair, p13, f72, o72 };
	static Vector3[] office73 = new Vector3[] { stair, p13, f73, o73 };
	static Vector3[] office74 = new Vector3[] { stair, p13, p9, f74, o74 };
	static Vector3[] office75 = new Vector3[] { stair, p13, p9, f75, o75 };
	static Vector3[] office76 = new Vector3[] { stair, p13, p9, f76, o76 };
	static Vector3[] office77 = new Vector3[] { stair, p13, p9, f77, o77 };
	static Vector3[] office78 = new Vector3[] { stair, p13, p9, f78, o78 };
	static Vector3[] office79 = new Vector3[] { stair, p1, p2, p14, f79, o79 };
	static Vector3[] changeStair = new Vector3[] { stair, p13, p5, upStair };

	static Vector3 pos1 = new Vector3 (296.3F, 77.6F, 236.3F);
	static Vector3 lookat1 = new Vector3 (292.7F, 33.0F, 205.0F);
	static Vector3 pos2 = new Vector3 (293.6F, 73.4F, 225.5F);
	static Vector3 lookat2 = new Vector3 (292.7F, 43.7F, 205.0F);
	static Vector3 pos3 = new Vector3 (301.2F, 67.0F, 232.4F);
	static Vector3 lookat3 = new Vector3 (292.7F, 33.0F, 205.0F);
	static Vector3 pos4 = new Vector3 (301.2F, 67.0F, 232.4F);
	static Vector3 lookat4 = new Vector3 (292.7F, 33.0F, 205.0F);
	static Vector3 pos5 = new Vector3 (296.3F, 77.6F, 236.3F);
	static Vector3 lookat5 = new Vector3 (292.7F, 33.0F, 205.0F);
	static Vector3 pos6 = new Vector3 (303.7F, 68.8F, 232.3F);
	static Vector3 lookat6 = new Vector3 (298.7F, 33.9F, 205.0F);
	static Vector3 pos7 = new Vector3 (294.3F, 68.3F, 234.0F);
	static Vector3 lookat7 = new Vector3 (292.7F, 33.0F, 205.0F);
	static Vector3 pos8 = new Vector3 (294.3F, 68.3F, 234.0F);
	static Vector3 lookat8 = new Vector3 (292.7F, 33.0F, 205.0F);
	static Vector3 pos9 = new Vector3 (294.3F, 68.3F, 234.0F);
	static Vector3 lookat9 = new Vector3 (292.7F, 33.0F, 205.0F);
	static Vector3 pos10 = new Vector3 (294.3F, 68.3F, 234.0F);
	static Vector3 lookat10 = new Vector3 (292.7F, 33.0F, 205.0F);
	static Vector3 pos11 = new Vector3 (320.3F, 65.8F, 249.1F);
	static Vector3 lookat11 = new Vector3 (300.1F, 17.3F, 205.0F);
	static Vector3 pos24 = new Vector3 (287.4F, 64.0F, 249.9F);
	static Vector3 lookat24 = new Vector3 (294.7F, 23.7F, 205.0F);
	static Vector3 pos30 = new Vector3 (264.8F, 65.3F, 240.6F);
	static Vector3 lookat30 = new Vector3 (286.5F, 25.9F, 205.0F);
	static Vector3 pos34 = new Vector3 (297.7F, 67.2F, 249.0F);
	static Vector3 lookat34 = new Vector3 (298.2F, 23.4F, 205.0F);
	static Vector3 pos40 = new Vector3 (273.2F, 64.3F, 246.7F);
	static Vector3 lookat40 = new Vector3 (293.9F, 21.4F, 205.0F);
	static Vector3 pos43 = new Vector3 (295.5F, 72.7F, 259.7F);
	static Vector3 lookat43 = new Vector3 (292.7F, 18.4F, 205.0F);
	static Vector3 pos44 = new Vector3 (290.7F, 76.4F, 227.4F);
	static Vector3 lookat44 = new Vector3 (292.7F, 40.0F, 205.0F);
	static Vector3 pos48 = new Vector3 (322.2F, 64.9F, 250.1F);
	static Vector3 lookat48 = new Vector3 (300.1F, 16.2F, 205.0F);
	static Vector3 pos51 = new Vector3 (263.0F, 64.8F, 224.5F);
	static Vector3 lookat51 = new Vector3 (282.4F, 36.2F, 205.0F);
	static Vector3 pos54 = new Vector3 (291.4F, 72.2F, 229.1F);
	static Vector3 lookat54 = new Vector3 (292.7F, 37.2F, 205.0F);
	static Vector3 pos57 = new Vector3 (260.8F, 70.3F, 237.4F);
	static Vector3 lookat57 = new Vector3 (284.8F, 28.5F, 205.0F);
	static Vector3 pos61 = new Vector3 (292.5F, 73.4F, 261.9F);
	static Vector3 lookat61 = new Vector3 (292.7F, 15.3F, 205.0F);
	static Vector3 pos63 = new Vector3 (292.7F, 75.6F, 226.9F);
	static Vector3 lookat63 = new Vector3 (292.7F, 38.1F, 205.0F);
	static Vector3 pos66 = new Vector3 (259.5F, 66.4F, 222.9F);
	static Vector3 lookat66 = new Vector3 (277.5F, 39.3F, 205.0F);
	static Vector3 pos74 = new Vector3 (253.6F, 72.1F, 222.0F);
	static Vector3 lookat74 = new Vector3 (276.2F, 41.6F, 205.0F);
	static Vector3 poschangeStair = new Vector3 (275.5f, 36.2f, 249.4f);
	static Vector3 lookatchangeStair = new Vector3 (293.8f, 9.7f, 205.0f);


	static Vector3[] start1 = new Vector3[] { stair, p1};
	static Vector3[] start2 = new Vector3[] { stair, p1, p2};
	static Vector3[] start3 = new Vector3[] { stair, p1, p3};
	static Vector3[] start4 = new Vector3[] { stair, p1, p3, p4};
	static Vector3[] start5 = new Vector3[] { stair, p13, p5};
	static Vector3[] start6 = new Vector3[] { stair, p1, p2, p6};
	static Vector3[] start7 = new Vector3[] { stair, p1, p2, p7};
	static Vector3[] start8 = new Vector3[] { stair, p13, p8};
	static Vector3[] start9 = new Vector3[] { stair, p13, p9};
	static Vector3[] start10 = new Vector3[] { stair, p13, p10};
	static Vector3[] start11 = new Vector3[] { stair, p13, p11};
	static Vector3[] start12 = new Vector3[] { stair, p13, p12};
	static Vector3[] start13 = new Vector3[] { stair, p13};
	static Vector3[] start14 = new Vector3[] { stair, p1, p2, p14};

	public Dictionary<string, Vector3[]> dictionary = new Dictionary<string, Vector3[]>();
	
	public Dictionary<string,Vector3> PositnCamera = new Dictionary<string, Vector3> ();
	public Dictionary<string,Vector3> LookatCamera = new Dictionary<string, Vector3> ();

	public Dictionary<string, Vector3[]> dicStart = new Dictionary<string, Vector3[]>();

	public Point8_2()
	{
		
		LookatCamera.Add("office1",lookat1);
		LookatCamera.Add("office2",lookat2);
		LookatCamera.Add("office3",lookat3);
		LookatCamera.Add("office4",lookat4);
		LookatCamera.Add("office5",lookat5);
		LookatCamera.Add("office6",lookat6);
		LookatCamera.Add("office7",lookat7);
		LookatCamera.Add("office8",lookat8);
		LookatCamera.Add("office9",lookat9);
		LookatCamera.Add("office10",lookat10);
		LookatCamera.Add("office11",lookat11);
		LookatCamera.Add("office12",lookat11);
		LookatCamera.Add("office13",lookat11);
		LookatCamera.Add("office14",lookat11);
		LookatCamera.Add("office15",lookat11);
		LookatCamera.Add("office16",lookat11);
		LookatCamera.Add("office17",lookat11);
		LookatCamera.Add("office18",lookat11);
		LookatCamera.Add("office19",lookat11);
		LookatCamera.Add("office20",lookat11);
		LookatCamera.Add("office21",lookat11);
		LookatCamera.Add("office22",lookat11);
		LookatCamera.Add("office23",lookat11);
		LookatCamera.Add("office24",lookat24);
		LookatCamera.Add("office25",lookat24);
		LookatCamera.Add("office26",lookat24);
		LookatCamera.Add("office27",lookat24);
		LookatCamera.Add("office28",lookat24);
		LookatCamera.Add("office29",lookat24);
		LookatCamera.Add("office30",lookat30);
		LookatCamera.Add("office31",lookat30);
		LookatCamera.Add("office32",lookat30);
		LookatCamera.Add("office33",lookat30);
		LookatCamera.Add("office34",lookat34);
		LookatCamera.Add("office35",lookat34);
		LookatCamera.Add("office36",lookat34);
		LookatCamera.Add("office37",lookat34);
		LookatCamera.Add("office38",lookat34);
		LookatCamera.Add("office39",lookat34);
		LookatCamera.Add("office40",lookat40);
		LookatCamera.Add("office41",lookat40);
		LookatCamera.Add("office42",lookat40);
		LookatCamera.Add("office43",lookat43);
		LookatCamera.Add("office44",lookat44);
		LookatCamera.Add("office45",lookat44);
		LookatCamera.Add("office46",lookat44);
		LookatCamera.Add("office47",lookat44);
		LookatCamera.Add("office48",lookat48);
		LookatCamera.Add("office49",lookat48);
		LookatCamera.Add("office50",lookat48);
		LookatCamera.Add("office51",lookat51);
		LookatCamera.Add("office52",lookat51);
		LookatCamera.Add("office53",lookat51);
		LookatCamera.Add("office54",lookat54);
		LookatCamera.Add("office55",lookat54);
		LookatCamera.Add("office56",lookat54);
		LookatCamera.Add("office57",lookat57);
		LookatCamera.Add("office58",lookat57);
		LookatCamera.Add("office59",lookat57);
		LookatCamera.Add("office60",lookat57);
		LookatCamera.Add("office61",lookat61);
		LookatCamera.Add("office62",lookat61);
		LookatCamera.Add("office63",lookat63);
		LookatCamera.Add("office64",lookat63);
		LookatCamera.Add("office65",lookat63);
		LookatCamera.Add("office66",lookat66);
		LookatCamera.Add("office67",lookat66);
		LookatCamera.Add("office68",lookat66);
		LookatCamera.Add("office69",lookat66);
		LookatCamera.Add("office70",lookat66);
		LookatCamera.Add("office71",lookat66);
		LookatCamera.Add("office72",lookat66);
		LookatCamera.Add("office73",lookat66);
		LookatCamera.Add("office74",lookat74);
		LookatCamera.Add("office75",lookat74);
		LookatCamera.Add("office76",lookat74);
		LookatCamera.Add("office77",lookat74);
		LookatCamera.Add("office78",lookat74);
		LookatCamera.Add("office79",lookat74);
		LookatCamera.Add("changeStair",lookatchangeStair);

		PositnCamera.Add("office1",pos1);
		PositnCamera.Add("office2",pos2);
		PositnCamera.Add("office3",pos3);
		PositnCamera.Add("office4",pos4);
		PositnCamera.Add("office5",pos5);
		PositnCamera.Add("office6",pos6);
		PositnCamera.Add("office7",pos7);
		PositnCamera.Add("office8",pos8);
		PositnCamera.Add("office9",pos9);
		PositnCamera.Add("office10",pos10);
		PositnCamera.Add("office11",pos11);
		PositnCamera.Add("office12",pos11);
		PositnCamera.Add("office13",pos11);
		PositnCamera.Add("office14",pos11);
		PositnCamera.Add("office15",pos11);
		PositnCamera.Add("office16",pos11);
		PositnCamera.Add("office17",pos11);
		PositnCamera.Add("office18",pos11);
		PositnCamera.Add("office19",pos11);
		PositnCamera.Add("office20",pos11);
		PositnCamera.Add("office21",pos11);
		PositnCamera.Add("office22",pos11);
		PositnCamera.Add("office23",pos11);
		PositnCamera.Add("office24",pos24);
		PositnCamera.Add("office25",pos24);
		PositnCamera.Add("office26",pos24);
		PositnCamera.Add("office27",pos24);
		PositnCamera.Add("office28",pos24);
		PositnCamera.Add("office29",pos24);
		PositnCamera.Add("office30",pos30);
		PositnCamera.Add("office31",pos30);
		PositnCamera.Add("office32",pos30);
		PositnCamera.Add("office33",pos30);
		PositnCamera.Add("office34",pos34);
		PositnCamera.Add("office35",pos34);
		PositnCamera.Add("office36",pos34);
		PositnCamera.Add("office37",pos34);
		PositnCamera.Add("office38",pos34);
		PositnCamera.Add("office39",pos34);
		PositnCamera.Add("office40",pos40);
		PositnCamera.Add("office41",pos40);
		PositnCamera.Add("office42",pos40);
		PositnCamera.Add("office43",pos43);
		PositnCamera.Add("office44",pos44);
		PositnCamera.Add("office45",pos44);
		PositnCamera.Add("office46",pos44);
		PositnCamera.Add("office47",pos44);
		PositnCamera.Add("office48",pos48);
		PositnCamera.Add("office49",pos48);
		PositnCamera.Add("office50",pos48);
		PositnCamera.Add("office51",pos51);
		PositnCamera.Add("office52",pos51);
		PositnCamera.Add("office53",pos51);
		PositnCamera.Add("office54",pos54);
		PositnCamera.Add("office55",pos54);
		PositnCamera.Add("office56",pos54);
		PositnCamera.Add("office57",pos57);
		PositnCamera.Add("office58",pos57);
		PositnCamera.Add("office59",pos57);
		PositnCamera.Add("office60",pos57);
		PositnCamera.Add("office61",pos61);
		PositnCamera.Add("office62",pos61);
		PositnCamera.Add("office63",pos63);
		PositnCamera.Add("office64",pos63);
		PositnCamera.Add("office65",pos63);
		PositnCamera.Add("office66",pos66);
		PositnCamera.Add("office67",pos66);
		PositnCamera.Add("office68",pos66);
		PositnCamera.Add("office69",pos66);
		PositnCamera.Add("office70",pos66);
		PositnCamera.Add("office71",pos66);
		PositnCamera.Add("office72",pos66);
		PositnCamera.Add("office73",pos66);
		PositnCamera.Add("office74",pos74);
		PositnCamera.Add("office75",pos74);
		PositnCamera.Add("office76",pos74);
		PositnCamera.Add("office77",pos74);
		PositnCamera.Add("office78",pos74);
		PositnCamera.Add("office79",pos74);
		PositnCamera.Add("changeStair",poschangeStair);


		dictionary.Add("office1",office1);
		dictionary.Add("office2",office2);
		dictionary.Add("office3",office3);
		dictionary.Add("office4",office4);
		dictionary.Add("office5",office5);
		dictionary.Add("office6",office6);
		dictionary.Add("office7",office7);
		dictionary.Add("office8",office8);
		dictionary.Add("office9",office9);
		dictionary.Add("office10",office10);
		dictionary.Add("office11",office11);
		dictionary.Add("office12",office12);
		dictionary.Add("office13",office13);
		dictionary.Add("office14",office14);
		dictionary.Add("office15",office15);
		dictionary.Add("office16",office16);
		dictionary.Add("office17",office17);
		dictionary.Add("office18",office18);
		dictionary.Add("office19",office19);
		dictionary.Add("office20",office20);
		dictionary.Add("office21",office21);
		dictionary.Add("office22",office22);
		dictionary.Add("office23",office23);
		dictionary.Add("office24",office24);
		dictionary.Add("office25",office25);
		dictionary.Add("office26",office26);
		dictionary.Add("office27",office27);
		dictionary.Add("office28",office28);
		dictionary.Add("office29",office29);
		dictionary.Add("office30",office30);
		dictionary.Add("office31",office31);
		dictionary.Add("office32",office32);
		dictionary.Add("office33",office33);
		dictionary.Add("office34",office34);
		dictionary.Add("office35",office35);
		dictionary.Add("office36",office36);
		dictionary.Add("office37",office37);
		dictionary.Add("office38",office38);
		dictionary.Add("office39",office39);
		dictionary.Add("office40",office40);
		dictionary.Add("office41",office41);
		dictionary.Add("office42",office42);
		dictionary.Add("office43",office43);
		dictionary.Add("office44",office44);
		dictionary.Add("office45",office45);
		dictionary.Add("office46",office46);
		dictionary.Add("office47",office47);
		dictionary.Add("office48",office48);
		dictionary.Add("office49",office49);
		dictionary.Add("office50",office50);
		dictionary.Add("office51",office51);
		dictionary.Add("office52",office52);
		dictionary.Add("office53",office53);
		dictionary.Add("office54",office54);
		dictionary.Add("office55",office55);
		dictionary.Add("office56",office56);
		dictionary.Add("office57",office57);
		dictionary.Add("office58",office58);
		dictionary.Add("office59",office59);
		dictionary.Add("office60",office60);
		dictionary.Add("office61",office61);
		dictionary.Add("office62",office62);
		dictionary.Add("office63",office63);
		dictionary.Add("office64",office64);
		dictionary.Add("office65",office65);
		dictionary.Add("office66",office66);
		dictionary.Add("office67",office67);
		dictionary.Add("office68",office68);
		dictionary.Add("office69",office69);
		dictionary.Add("office70",office70);
		dictionary.Add("office71",office71);
		dictionary.Add("office72",office72);
		dictionary.Add("office73",office73);
		dictionary.Add("office74",office74);
		dictionary.Add("office75",office75);
		dictionary.Add("office76",office76);
		dictionary.Add("office77",office77);
		dictionary.Add("office78",office78);
		dictionary.Add("office79",office79);
		dictionary.Add ("changeStair", changeStair);

		dicStart.Add ("start1", start1);
		dicStart.Add ("start2", start2);
		dicStart.Add ("start3", start3);
		dicStart.Add ("start4", start4);
		dicStart.Add ("start5", start5);
		dicStart.Add ("start6", start6);
		dicStart.Add ("start7", start7);
		dicStart.Add ("start8", start8);
		dicStart.Add ("start9", start9);
		dicStart.Add ("start10", start10);
		dicStart.Add ("start11", start11);
		dicStart.Add ("start12", start12);
		dicStart.Add ("start13", start13);
		dicStart.Add ("start14", start14);
	}
	public void addNewOffice(string name, string nameStart, Vector3[] append,string camera)
	{
		Vector3[] start = dicStart [nameStart];
		int length = start.Length + append.Length;
		Vector3[] arrayVectorOffice = new Vector3[length];
		for (int i = 0; i< length; i++) {
			if(i<start.Length){
				arrayVectorOffice[i] = start[i];
			}
			else {
				arrayVectorOffice[i] = append[i - start.Length];
			}
		}
		dictionary.Add (name, arrayVectorOffice);
		PositnCamera.Add(name, PositnCamera[camera]);
		LookatCamera.Add(name,LookatCamera[camera]);
	}
}