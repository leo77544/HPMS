using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// config 的摘要说明
/// </summary>
public class config
{
    public config()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    // 应用ID,您的APPID
    public static string app_id = "2016092700610299";

    // 支付宝网关
    public static string gatewayUrl = "https://openapi.alipaydev.com/gateway.do";

    // 商户私钥，您的原始格式RSA私钥
    public static string private_key = "MIIEpQIBAAKCAQEAv75IOROoYy25FTf4Q4WY5W77jHBs7yK01kPFVM6DOWM46G4kyBjzt7Ax0Lb2cdpirdaYpYvtmVSQg5nmpF6z1SMzG2COKQSGqoDz6P0LvYFV1nSGoEmkVLdBDtFgQJsAaVVOjQFEUOQHoduiZVYL9Ar8xoLTGb+Ijz5m1OvTydXJ9KdO9L8rsWNNjZ1jyr5lJ6gVOdOMO0bQAn9n86+hZ7JuthSiypXNSddYefWKpZ4CIoD4mYp9J99jO78cOp0vjRIOWSqki5i6ef+PsJ5Jbc9IXZLyTpoNp4QHTplM9CE6RaFeH2WkEcLIHWrdMRN7n1rlAqdeTbTWaI8x7d2WnQIDAQABAoIBAQCoY+Cjl5ry9s2rT8sM6X/8RjpN/NH+NXmhDkV3lCF0PapVnZ1ZyWgIMomdJYFLPaIZzvOht0CDvttnZ7pBMhY2oUIZ0fMnHJ1zkeoi/E/aLoKG4zD0BZh2+bT94Wzpb/atisiAVtN7QrddMzjsS+QVf6y8XVotK6MvQXsnlLAbeMp4pyAKivK79CrdjRWI+ZwK2yS9F9N+hJ9WIrR8deUVwULWkMlJlZuEkut+qCj1a1GGvYD0veZCpEFTR2ja/DPm84JxXv/GcDVqR2t/BbqzKVP+/ZG7/OJ0IzjyLpE8gCGz//otZCM+Cy1S9A3ACwlSQ3CICI3rVeDEhXpPqUA1AoGBAOyCBTi48TBTIgeWicIyv9VltVwE+wH1wCXqyRI1pvtsOG5Fe1iXOlqRW8EbGI4KlI3mu9s7xrDsURyDbT3zfYsTEMfUzqsSJ918bxckBU6Yook5A981tzr3R5FYE+x8hktaKmNHO4XRyvrGV9K4cZVOTOgB2dVQghujVCZqWOOzAoGBAM+LytlUaRoTud//cqkfsNxbjBycp0ErItF0Diko+3ig4l6YG1xq6qlqeAGGx8fgnU/gPHHhTcWxGUBrW88L4IbqPxPZ725ogfmcVWPi++uqcYmXx5vfaWW0lU6/kbIZfXOZwym8twsQsG3dblX02JFDHa1RCdumUV7utfoxY7RvAoGBAK83cHjig0VjAZ4PiAXIpViKnn8K7Y85Kt6sf8Su3QP93BzN+yDaARBiClEZKuroqcArRdeZBI3Eth7iu4cfIk5rlI4HeglBTSmI66CAPjJJYHk7NUQjvpi/5FSopTIZ20BuD2M3vcBZegCp+xyRKw0LUmy8Gk8v8wRYz5oaRbqDAoGANHi6QzHlFJOyJaCWo42AkGWQydcNLhuyxNOblOpokXnTYWkBWd8qDsT9LB2gOrdd7kjZ30y/9eAtayz5XCI7lMB6TBGISBih67KLoCJN4KoJ5Gh8LbtREUaTjQI/2pA5OFXCkrXEbUa95DjcYVzyt98JDL11SZQF9INTfLqp438CgYEAxII9QAWun9uH/p0G9wvVprYex0ZhAlE1RTZVrwcS/wJ1gKygXLVJhFQmqTeyE4bxi+UWR026C8JuYtmHAgur56O1VH44Ex2O0yxyH+bJTGYjBB35dYOzWZxmcGV7xS2DDakUArwnNrx5fRPKTx+lfLtJ95rs/K5wWrVPwe6P3u4=";

    // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
    public static string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAv75IOROoYy25FTf4Q4WY5W77jHBs7yK01kPFVM6DOWM46G4kyBjzt7Ax0Lb2cdpirdaYpYvtmVSQg5nmpF6z1SMzG2COKQSGqoDz6P0LvYFV1nSGoEmkVLdBDtFgQJsAaVVOjQFEUOQHoduiZVYL9Ar8xoLTGb+Ijz5m1OvTydXJ9KdO9L8rsWNNjZ1jyr5lJ6gVOdOMO0bQAn9n86+hZ7JuthSiypXNSddYefWKpZ4CIoD4mYp9J99jO78cOp0vjRIOWSqki5i6ef+PsJ5Jbc9IXZLyTpoNp4QHTplM9CE6RaFeH2WkEcLIHWrdMRN7n1rlAqdeTbTWaI8x7d2WnQIDAQAB";

    // 签名方式
    public static string sign_type = "RSA2";

    // 编码格式
    public static string charset = "UTF-8";
}