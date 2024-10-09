window.redirectToCheckout = function (sessionId) {
    var stripe = Stripe('pk_test_51PcSc2J9woBYW5xV8LxR5f5XAVMUmpzMYqFv5K3cirDDh1lzepWaG3kjWQQnuNYZk5oMBScAp8SI17XlvDgwxjfv00mRIwSFyS');
    stripe.redirectToCheckout({
        sessionId: sessionId
    }).then(function (result) {
        if (result.error) {
            console.error(result.error.message);
        }
    });
};
