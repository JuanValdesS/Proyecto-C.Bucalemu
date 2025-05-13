/**
 * Import function triggers from their respective submodules:
 *
 * const {onCall} = require("firebase-functions/v2/https");
 * const {onDocumentWritten} = require("firebase-functions/v2/firestore");
 *
 * See a full list of supported triggers at https://firebase.google.com/docs/functions
 */

const {onRequest} = require("firebase-functions/v2/https");
const logger = require("firebase-functions/logger");

// Create and deploy your first functions
// https://firebase.google.com/docs/functions/get-started

// exports.helloWorld = onRequest((request, response) => {
//   logger.info("Hello logs!", {structuredData: true});
//   response.send("Hello from Firebase!");
// });


const functions = require("firebase-functions");
const nodemailer = require("nodemailer");

// configuración del correo
const transporter = nodemailer.createTransport({
  service: "hotmail",
  auth: {
    user: "diegovasquezvaldivia@hotmail.com", // <- tu correo de envío
    pass: "pzogumuramucgbbu",         // <- tu contraseña de correo o contraseña de aplicación
  },
});

// Función que escucha Firestore (o Realtime Database) para enviar el correo
exports.enviarReportePorCorreo = functions.database.ref('/Reportes/{reporteId}')
    .onCreate((snapshot, context) => {
        const reporte = snapshot.val();
        const observacion = reporte.Reporte;
        const emailDestino = reporte.Email;
        const fecha = reporte.Fecha;

        const mailOptions = {
            from: 'Constructora Bucalemu <tucorreo@hotmail.com>',
            to: emailDestino,
            subject: `Nuevo reporte registrado - ${fecha}`,
            text: `Se ha recibido un nuevo reporte:\n\n${observacion}\n\nFecha de registro: ${fecha}`
        };

        return transporter.sendMail(mailOptions)
            .then(() => {
                console.log('Correo enviado exitosamente a', emailDestino);
                return null;
            })
            .catch((error) => {
                console.error('Error enviando correo:', error);
                return null;
            });
    });