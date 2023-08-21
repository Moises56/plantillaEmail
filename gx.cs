//* -> Parametros
for each ParametroCorreo
    &Host = Host
    &Port = Port
    &SenderName = SenderName
    &SenderAddress = SenderAddress
    &UserName = UserName
    &Password = Password
    &Asunto = Asunto
    &MensajeCorreo = MensajeCorreo
    &MensajeVencimiento = MensajeVencimiento
    &MensajeFinaliza = MensajeFinaliza
    &MensajeCorreo2 = MensajeCorreo2
endfor

&FechaHTML = "Tegucigalpa, " + &Today.Day().ToString() + " de " + &Today.MonthName() + &Today.Year().ToString()
&HoraHTML = SysTime()

For each CorreoMasivo
&count += 1
&MailRecipient.Address = Correo
&MailRecipient.Name = Contribuyente
&MailMessage.To.Clear()
&MailMessage.To.Add(&MailRecipient)
&MailMessage.Subject = &Asunto
&MailMessage.Text = 'AMDC-Recaudación'
&Nombre = TUserNombre
&MailMessage.HTMLText = '<head><title>Correo</title><style>body{font-family:Arial,Helvetica,sans-serif;font-size:14px;}.card{width:600px;box-shadow:0px 2px 4px rgba(0,0,0,1.4);padding:20px;border-radius:5px;margin:0 auto;background-image:url("https://amdc.hn/wp-content/uploads/2023/08/TORRE.png");background-size:cover;background-position:center;}.banner{width:100%;height:150px;background-image:url("https://amdc.hn/wp-content/uploads/2023/08/recaudacion.png");background-size:cover;background-position:center;color:#fff;text-align:center;padding:1px;border-radius:5px 5px 0 0;margin-bottom:20px;}h1{font-size:24px;color:#5ccedf;margin-bottom:20px;font-family:Arial,Helvetica,sans-serif;}h2{font-size:19px;color:#000000;margin-bottom:20px;font-family:Arial,Helvetica,sans-serif;}p{font-family:Arial,Helvetica,sans-serif;text-align:justify;}.just{text-align:right;}.justfooter{text-align:center;}.table{width:100%;border-collapse:collapse;margin-top:20px;}.table td{padding:10px;border:1px solid #ccc;}.btn{display:inline-block;padding:10px 20px;background-color:#5ccedf;color:#fff;text-decoration:none;border-radius:5px;margin-top:20px;margin-left:120px;}.btn:hover{background-color:#005454;background:#5ccedf!important;box-shadow:0 0 5px #5ccedf,0 0 25px #5ccedf,0 0 50px #5ccedf,0 0 200px #5ccedf!important;color:#180303!important;}.centrar{text-align:center;color:#5ccedf;font-size:20px;font-weight:bold;font-family:Arial,Helvetica,sans-serif;}.textMensaje{text-align:justify;font-size:15px;font-family:Arial,Helvetica,sans-serif;}.textP{text-align:center;font-size:14px;font-family:Arial,Helvetica,sans-serif;font-weight:bold;}</style></head><div><div class="card"><div class="banner"></div><center><h1>ALCALDÍA MUNICIPAL DEL DISTRITO CENTRAL</h1><hr /><p class="just">'+ &FechaHTML +'</p></center><span>Señor(a):</span><p><b>' + Contribuyente + '</b></p><br/><p>Estimado Contribuyente </p><p class="textMensaje">' + &MensajeCorreo + '<b>' + &MensajeVencimiento + '</b> <b><u>' + &MensajeFinaliza + '</u></b>, ' + &MensajeCorreo2 + ' </p><p>Su estado de cuenta lo puede consultar:</p><ul><li>Llamando al número <b>2220-6083</b></li><li>Ingresar a la página web : <a href="https://amdc.hn/">https://amdc.hn/</a></li><li>Abocarse a las oficinas de atención al cliente ubicadas en el edificio AER y centro Comercial Castaños.</li><li>Visitar las mesas informativas que tenemos en diferentes puntos de la ciudad.</li></ul><div class="centrar">“Inversión para el Desarrollo, Tus Impuestos, Tu Ciudad".</div><br /><p class="textP">Gerencia de Recaudación y Control Financiero</p><p class="textP">Alcaldía Municipal del Distrito Central</p><br /><hr /></div></body>'
&SMTPSession.Host = &Host
&SMTPSession.Port = &Port
&SMTPSession.Sender.Name = &SenderName
&SMTPSession.Sender.Address = &SenderAddress
&SMTPSession.Authentication = 1
&SMTPSession.Secure = 1
&SMTPSession.UserName = &UserName
&SMTPSession.Password = &Password

&SMTPSession.Login()

//msg(str(&SMTPSession.ErrCode) + ' ' + &SMTPSession.ErrDescription)
&SMTPSession.Send(&MailMessage)
msg(str(&SMTPSession.ErrCode) + 'Errores' + &SMTPSession.ErrDescription+ ' ' + 'Correo Enviado correctamente')
&SMTPSession.Logout()
if &count = 5 // los primeros 5 correos
    exit
endif
endFor


&MailMessage.HTMLText = '<head><title>Recaudación-AMDC</title><style>body{font-family:Arial,Helvetica,sans-serif;font-size:14px;}.card{width:600px;box-shadow:0px 2px 4px rgba(0,0,0,1.4);padding:20px;border-radius:5px;margin:0 auto;background-size:cover;background-position:center;}.banner{width:106.4%;height:175px;background-image:url(https://res.cloudinary.com/dilhuayui/image/upload/v1692596057/reca_fexjzy.png);background-size:cover;background-position:center;color:#fff;text-align:center;padding:1px;border-radius:5px 5px 0 0;margin-bottom:20px;margin-left:-20px;margin-top:-20px;}h1{font-size:24px;color:#5ccedf;margin-bottom:20px;font-family:Arial,Helvetica,sans-serif;}h2{font-size:19px;color:#000000;margin-bottom:20px;font-family:Arial,Helvetica,sans-serif;}p{font-family:Arial,Helvetica,sans-serif;text-align:justify;}.just{text-align:right;}.justfooter{text-align:center;}.table{width:100%;border-collapse:collapse;margin-top:20px;}.table td{padding:10px;border:1px solid #ccc;}.btn{display:inline-block;padding:10px 20px;background-color:#5ccedf;color:#fff;text-decoration:none;border-radius:5px;margin-top:20px;margin-left:120px;}.btn:hover{background-color:#005454;background:#5ccedf!important;box-shadow:0 0 5px #5ccedf,0 0 25px #5ccedf,0 0 50px #5ccedf,0 0 200px #5ccedf!important;color:#180303!important;}.centrar{text-align:center;color:#5ccedf;font-size:20px;font-weight:bold;font-family:Arial,Helvetica,sans-serif;}.textMensaje{text-align:justify;font-size:15px;font-family:Arial,Helvetica,sans-serif;}.textP{text-align:center;font-size:14px;font-family:Arial,Helvetica,sans-serif;font-weight:bold;}</style></head><div><div class="card"><div class="banner"></div><center><hr/><p class="just">'+ &FechaHTML +'</p></center><span>Señor(a):</span><p><b>Mou Grind</b></p><br/><p>Estimado Contribuyente </p><p class="textMensaje">' + &MensajeCorreo + '<b>' + &MensajeVencimiento + '</b> <b><u>' + &MensajeFinaliza + '</u></b>, ' + &MensajeCorreo2 + ' </p><p>Su estado de cuenta lo puede consultar:</p><ul><li>Llamando al número <b>2220-6083</b></li><li>Ingresar a la página web : <a href="https://amdc.hn/">https://amdc.hn/</a></li><li>Abocarse a las oficinas de atención al cliente ubicadas en el edificio AER y centro Comercial Castaños.</li><li>Visitar las mesas informativas que tenemos en diferentes puntos de la ciudad.</li></ul><div class="centrar">“Inversión para el Desarrollo, Tus Impuestos, Tu Ciudad".</div><br/><p class="textP">Gerencia de Recaudación y Control Financiero</p><p class="textP">Alcaldía Municipal del Distrito Central</p><br/><hr/></div></body>'
	

//
&SMTPSession.Host = 'us2.smtp.mailhostbox.com'
&SMTPSession.Port = 587

&SMTPSession.Sender.Name = 'APP Linea 100'
&SMTPSession.Sender.Address = 'linea100.app@amdc.hn'
&SMTPSession.Authentication = 1
&SMTPSession.Secure = 1
&SMTPSession.UserName = 'linea100.app@amdc.hn'
&SMTPSession.Password = 'Appcorreo2023*'
&SMTPSession.Login()

gerenciarecaudacion@mail2.amdc.hn

Detalles del usuario
Nombre para mostrar: Gerencia Recaudación
Nombre de usuario: Gerenciarecaudacion@mail2.amdc.hn
Contraseña: Woj46033