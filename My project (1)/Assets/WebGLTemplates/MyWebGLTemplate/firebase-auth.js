var firebaseConfig = {
    apiKey: "AIzaSyBFqhghLETNg57bKnAC0Cs89LP9spLi8XY",

    authDomain: "axes-and-bows.firebaseapp.com",

    projectId: "axes-and-bows",

    storageBucket: "axes-and-bows.firebasestorage.app",

    messagingSenderId: "437456960654",

    appId: "1:437456960654:web:7d97f233ea7f6dfb861ddf",

    measurementId: "G-6EYWZL0NFK"

};
firebase.initializeApp(firebaseConfig);

function googleSignIn() {
    var provider = new firebase.auth.GoogleAuthProvider();
    firebase.auth().signInWithPopup(provider).then(function(result) {
        var user = result.user;
        // Llamar a Unity con los datos del usuario
        unityInstance.SendMessage('GoogleLogin', 'OnGoogleSignInCallback', user.getIdToken());
    }).catch(function(error) {
        console.log(error.message);
    });
}


