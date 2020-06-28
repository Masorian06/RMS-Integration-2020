import numpy as np
import matplotlib.pyplot as plt
import math

def splitdataset(dataset, trainsize, testsize, testdataset=None, featureoffset=None, outputfirst=None):
    """
    Splits the dataset into a train and test split
    If there is a separate testfile, it can be specified in testfile
    If a subset of features is desired, this can be specifed with featureinds; defaults to all
    Assumes output variable is the last variable
    """
    # Generate random indices without replacement, to make train and test sets disjoint
    randindices = np.random.choice(dataset.shape[0],trainsize+testsize, replace=False)
    featureend = dataset.shape[1]-1
    outputlocation = featureend    
    if featureoffset is None:
        featureoffset = 0
    if outputfirst is not None:
        featureoffset = featureoffset + 1
        featureend = featureend + 1
        outputlocation = 0
    
    Xtrain = dataset[randindices[0:trainsize],featureoffset:featureend]
    ytrain = dataset[randindices[0:trainsize],outputlocation]
    Xtest = dataset[randindices[trainsize:trainsize+testsize],featureoffset:featureend]
    ytest = dataset[randindices[trainsize:trainsize+testsize],outputlocation]

    if testdataset is not None:
        Xtest = dataset[:,featureoffset:featureend]
        ytest = dataset[:,outputlocation]        

    # Normalize features, with maximum value in training set
    # as realistically, this would be the only possibility    
#    for ii in range(Xtrain.shape[1]):
#        maxval = np.max(np.abs(Xtrain[:,ii]))
#        if maxval > 0:
#            Xtrain[:,ii] = np.divide(Xtrain[:,ii], maxval)
#            Xtest[:,ii] = np.divide(Xtest[:,ii], maxval)
                        
    # Add a column of ones; done after to avoid modifying entire dataset
    #Xtrain = np.hstack((Xtrain, np.ones((Xtrain.shape[0],1))))
    #Xtest = np.hstack((Xtest, np.ones((Xtest.shape[0],1))))
                              
    return ((Xtrain,ytrain), (Xtest,ytest))

def loadcsv(filename):
    dataset = np.genfromtxt(filename, delimiter=',')
    return dataset

def load_dataset(trainsize, testsize):
    """ A physics classification dataset """
    #filename = 'datasetAcc.csv'
    filename = 'dataset_norm.csv'
    dataset = loadcsv(filename)
    trainset, testset = splitdataset(dataset,trainsize, testsize)    
    return trainset,testset

def format_Data(trainset, testset):
    train_x = trainset[0]
    train_y = trainset[1]
    test_x = testset[0]
    test_y = testset[1]
    
    train_X = train_x.T
    train_Y = train_y.T
    test_X = test_x.T
    test_Y = test_y.T
    
    return train_X, train_Y, test_X, test_Y

def selectData(data, numData):
    data_Selected = data[:numData]
    
    return data_Selected

def relu(Z):

    A = np.maximum(0,Z)
    
    assert(A.shape == Z.shape)
    
    cache = Z 
    return A, cache

def relu_backward(dA, z):
    dZ = np.array(dA, copy=True) # just converting dz to a correct object.
    
    # When z <= 0, you should set dz to 0 as well. 
    dZ[z <= 0] = 0
    
    assert (dZ.shape == z.shape)
    
    return dZ

def sigmoid(Z):

    A = 1/(1+np.exp(-Z))
    cache = Z
    
    return A, cache

def sigmoid_backward(dA, cache):
    Z = cache
    
    s = 1/(1+np.exp(-Z))
    dZ = dA * s * (1-s)
    
    assert (dZ.shape == Z.shape)
    
    return dZ

def compute_cost(a3, Y):
    m = Y.shape[0]
    
    #logprobs = np.multiply(-np.log(a3),Y) + np.multiply(-np.log(1 - a3), 1 - Y)
    #cost = 1./m * np.sum(logprobs)
    
    cost = (1./(2*m)) * np.sum(np.square(a3 - Y))
    
    return cost

def cost_MSE(AL, y):
    
    m = y.shape[0]
    cost = 1./m * np.sum(np.square(AL - y))
    #cost = np.sum(np.square(AL - y))
    
    return cost
    
def cost_MAE(AL, y):
    
    m = y.shape[0]
    cost = 1./m * np.sum(np.abs(AL - y))
    
    return cost

def cost_MSLE(AL, y):
    
    m = y.shape[0]
    cost = 1./m * np.sum(np.square(np.log(AL + 1) - np.log(y + 1)))
    
    return cost

def cost_MAD(AL, y):
    
    m = y.shape[0]
    cost = np.median(np.abs(AL - np.median(y)))
    
    return cost

def compute_cost_with_regularization(A3, Y, parameters, lambd):
    m = Y.shape[0]
    
    cross_entropy_cost = compute_cost(A3, Y) # This gives you the cross-entropy part of the cost
    
    L2_regularization_cost = (lambd/m) * np.sum(np.abs(A3))#(lambd/2) * (np.sum(np.square(W1)) + np.sum(np.square(W2)) + np.sum(np.square(W3)))
    
    cost = cross_entropy_cost + L2_regularization_cost
    
    return cost

def initialize_parameters(layer_dims):
    parameters = {}
    L = len(layer_dims) # number of layers in the network

    for l in range(1, L):
        parameters['W' + str(l)] = np.random.randn(layer_dims[l], layer_dims[l-1]) *  np.sqrt(2 / layer_dims[l-1])
        parameters['b' + str(l)] = np.zeros((layer_dims[l], 1))
        
        assert(parameters['W' + str(l)].shape == (layer_dims[l], layer_dims[l-1]))
        assert(parameters['b' + str(l)].shape == (layer_dims[l], 1))
        
    return parameters

def initialize_adam(parameters) :
    
    L = len(parameters) // 2 # number of layers in the neural networks
    v = {}
    s = {}
    
    # Initialize v, s. Input: "parameters". Outputs: "v, s".
    for l in range(L):
        v["dW" + str(l+1)] = np.zeros_like(parameters["W" + str(l+1)])
        v["db" + str(l+1)] = np.zeros_like(parameters["b" + str(l+1)])
        s["dW" + str(l+1)] = np.zeros_like(parameters["W" + str(l+1)])
        s["db" + str(l+1)] = np.zeros_like(parameters["b" + str(l+1)])
    
    return v, s

def initialize_velocity(parameters):
    L = len(parameters) // 2 # number of layers in the neural networks
    v = {}
    
    # Initialize velocity
    for l in range(L):
        v["dW" + str(l+1)] = np.zeros_like(parameters["W" + str(l+1)])
        v["db" + str(l+1)] = np.zeros_like(parameters["b" + str(l+1)])
        
    return v

def update_parameters_with_momentum(parameters, gradients, v, beta, learning_rate):

    L = len(parameters) // 2 # number of layers in the neural networks
    
    # Momentum update for each parameter
    for l in range(L):
        v["dW" + str(l+1)] = beta*v['dW' + str(l+1)] + (1 - beta)*gradients['dW' + str(l+1)]
        v["db" + str(l+1)] = beta*v['db' + str(l+1)] + (1 - beta)*gradients['db' + str(l+1)]
        # update parameters
        parameters["W" + str(l+1)] = parameters['W' + str(l+1)] - learning_rate*v["dW" + str(l+1)] 
        parameters["b" + str(l+1)] = parameters['b' + str(l+1)] - learning_rate*v["db" + str(l+1)] 
        
    return parameters, v

def update_parameters_with_gd(parameters, gradients, learning_rate):

    L = len(parameters) // 2 # number of layers in the neural networks

    # Update rule for each parameter
    for l in range(L):
        parameters["W" + str(l+1)] = parameters['W' + str(l + 1)] - learning_rate * gradients['dW' + str(l + 1)] 
        parameters["b" + str(l+1)] = parameters['b' + str(l + 1)] - learning_rate * gradients['db' + str(l + 1)]
        
    return parameters

def random_mini_batches(X, Y, mini_batch_size, seed):
    m = X.shape[1]                  # number of training examples
    mini_batches = []
        
    permutation = list(np.random.permutation(m))
    shuffled_X = X[:,permutation]
    shuffled_Y = Y[permutation]

    num_complete_minibatches = math.floor(m/mini_batch_size) # number of mini batches of size mini_batch_size in your partitionning
    for k in range(0, num_complete_minibatches):

        mini_batch_X = shuffled_X[:, k * mini_batch_size : (k + 1) * mini_batch_size]
        mini_batch_Y = shuffled_Y[k * mini_batch_size : (k + 1) * mini_batch_size]

        mini_batch = (mini_batch_X, mini_batch_Y)
        mini_batches.append(mini_batch)
    
    # Handling the end case (last mini-batch < mini_batch_size)
    if m % mini_batch_size!= 0:

        mini_batch_X = shuffled_X[:, num_complete_minibatches * mini_batch_size:]
        mini_batch_Y = shuffled_Y[num_complete_minibatches * mini_batch_size:]

        mini_batch = (mini_batch_X, mini_batch_Y)
        mini_batches.append(mini_batch)
    
    return mini_batches

def forward_propagation_deep(X, parameters): 
    caches = []
    A = X
    L = len(parameters) // 2
    
    for l in range (1, L):
        A_prev = A
        A, cache = linear_activation_forward(A_prev, parameters['W' + str(l)], parameters['b' + str(l)], activation = "relu")
        caches.append(cache)
    AL, cache = linear_activation_forward(A, parameters['W' + str(L)], parameters['b' + str(L)], activation = "sigmoid")
    caches.append(cache)
        
    assert(AL.shape == (1, X.shape[1]))
    
    return AL, caches

def linear_activation_forward(A_prev, W, b, activation):
    if activation == "sigmoid":
        # Inputs: "A_prev, W, b". Outputs: "A, activation_cache".
        Z, linear_cache = linear_forward(A_prev, W, b)
        A, activation_cache = sigmoid(Z)
    
    elif activation == "relu":
        # Inputs: "A_prev, W, b". Outputs: "A, activation_cache".
        Z, linear_cache = linear_forward(A_prev, W, b)
        A, activation_cache = relu(Z)
    
    assert (A.shape == (W.shape[0], A_prev.shape[1]))
    cache = (linear_cache, activation_cache)

    return A, cache

def linear_forward(A, W, b):
    
    Z = W.dot(A) + b
    
    assert(Z.shape == (W.shape[0], A.shape[1]))
    cache = (A, W, b)
    
    return Z, cache

def backward_propagation_deep(AL, Y, caches, lamdb):
    gradients = {}
    L = len(caches)
    Y = Y.reshape(AL.shape)
    
    dAL = AL - Y #+ lambd/m
    
    current_cache = caches[L - 1]
    gradients["dA" + str(L - 1)], gradients["dW" + str(L)], gradients["db" + str(L)] = linear_activation_backward(dAL, current_cache, activation = "sigmoid")
    
    for l in reversed(range(L - 1)):
        current_cache = caches[l]
        dA_prev_temp, dW_temp, db_temp = linear_activation_backward(gradients["dA" + str(l + 1)], current_cache, activation = "relu")
        gradients["dA" + str(l)] = dA_prev_temp
        gradients["dW" + str(l + 1)] = dW_temp
        gradients["db" + str(l + 1)] = db_temp

    return gradients

def linear_activation_backward(dA, cache, activation):
    linear_cache, activation_cache = cache
    
    if activation == "relu":
        dZ = relu_backward(dA, activation_cache)
        dA_prev, dW, db = linear_backward(dZ, linear_cache)
        
    elif activation == "sigmoid":
        dZ = sigmoid_backward(dA, activation_cache)
        dA_prev, dW, db = linear_backward(dZ, linear_cache)
    
    return dA_prev, dW, db

def linear_backward(dZ, cache):
    A_prev, W, b = cache
    m = A_prev.shape[1]

    dW = (1 / m) * np.dot(dZ, A_prev.T)
    db = (1 / m) * np.sum(dZ, axis = 1, keepdims = True)
    dA_prev = np.dot(W.T, dZ)

    assert (dA_prev.shape == A_prev.shape)
    assert (dW.shape == W.shape)
    assert (db.shape == b.shape)
    
    return dA_prev, dW, db

def update_parameters_with_adam(parameters, gradients, v, s, t, learning_rate = 0.01,
                                beta1 = 0.9, beta2 = 0.999,  epsilon = 1e-8):
    
    L = len(parameters) // 2                 # number of layers in the neural networks
    v_corrected = {}                         # Initializing first moment estimate, python dictionary
    s_corrected = {}                         # Initializing second moment estimate, python dictionary
    
    for l in range(L):
        v["dW" + str(l+1)] = beta1 * v["dW" + str(l+1)] + (1 - beta1) * gradients['dW' + str(l+1)]
        v["db" + str(l+1)] = beta1 * v["db" + str(l+1)] + (1 - beta1) * gradients['db' + str(l+1)]

        v_corrected["dW" + str(l+1)] = v["dW" + str(l+1)] / (1 - np.power(beta1, t))
        v_corrected["db" + str(l+1)] = v["db" + str(l+1)] / (1 - np.power(beta1, t))

        s["dW" + str(l+1)] = beta2 * s["dW" + str(l+1)] + (1 - beta2) * np.power(gradients['dW' + str(l+1)], 2)
        s["db" + str(l+1)] = beta2 * s["db" + str(l+1)] + (1 - beta2) * np.power(gradients['db' + str(l+1)], 2)

        s_corrected["dW" + str(l+1)] = s["dW" + str(l+1)] / (1 - np.power(beta2, t))
        s_corrected["db" + str(l+1)] = s["db" + str(l+1)] / (1 - np.power(beta2, t))

        parameters["W" + str(l+1)] = parameters['W' + str(l+1)] - learning_rate * (v_corrected["dW" + str(l+1)] / np.sqrt(s_corrected["dW" + str(l+1)] + epsilon))
        parameters["b" + str(l+1)] = parameters['b' + str(l+1)] - learning_rate * (v_corrected["db" + str(l+1)] / np.sqrt(s_corrected["db" + str(l+1)] + epsilon))

    return parameters, v, s

def NN_model(X, Y, layers_dims, learning_rate, mini_batch_size, beta, num_epochs, lamdb, cost_method, optimizer,
          beta1 = 0.9, beta2 = 0.999,  epsilon = 1e-8, print_cost = True):


    L = len(layers_dims)             # number of layers in the neural networks
    costs = []                       # to keep track of the cost
    t = 0                            # initializing the counter required for Adam update
    seed = 0
    
    # Initialize parameters
    parameters = initialize_parameters(layers_dims)

    # Initialize the optimizer
    if optimizer == "gd":
        pass # no initialization required for gradient descent
    elif optimizer == "momentum":
        v = initialize_velocity(parameters)
    elif optimizer == "adam":
        v, s = initialize_adam(parameters)
    
    # Optimization loop for
    for i in range(num_epochs):
        # Define the random minibatches. We increment the seed to reshuffle differently the dataset after each epoch
        seed = seed + 1
        minibatches = random_mini_batches(X, Y, mini_batch_size, seed)

        for minibatch in minibatches:

            # Select a minibatch
            (minibatch_X, minibatch_Y) = minibatch

            # Forward propagation
            AL, caches = forward_propagation_deep(minibatch_X, parameters)

            # Compute cost
            #cost = compute_cost_with_regularization(AL, minibatch_Y, parameters, lamdb)
            if cost_method == "MSE":
                cost = cost_MSE(AL, minibatch_Y)
                
            elif cost_method == "MAE":
                cost = cost_MAE(AL, minibatch_Y)
                
            elif cost_method == "MSLE":
                cost = cost_MSLE(AL, minibatch_Y)
                
            elif cost_method == "MAD":
                cost = cost_MAD(AL, minibatch_Y)
                
            # Backward propagation
            gradients = backward_propagation_deep(AL, minibatch_Y, caches, lamdb)

            # Update parameters
            if optimizer == "gd":
                parameters = update_parameters_with_gd(parameters, gradients, learning_rate)
            elif optimizer == "momentum":
                parameters, v = update_parameters_with_momentum(parameters, gradients, v, beta, learning_rate)
            elif optimizer == "adam":
                t = t + 1 # Adam counter
                parameters, v, s = update_parameters_with_adam(parameters, gradients, v, s,
                                                               t, learning_rate, beta1, beta2,  epsilon)
    
        # Print the cost every 1000 epoch
        if print_cost and i % 1000 == 0:
            print ("Cost after epoch %i: %f" %(i, cost))
        if print_cost and i % 100 == 0:
            costs.append(cost)
                
    # plot the cost
    plt.plot(costs)
    plt.ylabel('cost')
    plt.xlabel('epochs (per 100)')
    plt.title("Learning rate = " + str(learning_rate))
    plt.show()

    return parameters, costs

def predict(X, y, parameters):
    m = X.shape[1]
    AL, caches_P = forward_propagation_deep(X, parameters)
    
    MSE = 1./m * np.sum(np.square(AL - y))
    MAE = 1./m * np.sum(np.abs(AL - y))
    MSLE = 1./m * np.sum(np.square(np.log(AL + 1) - np.log(y + 1)))
    MAD = np.median(np.abs(AL - np.median(y)))
    
    errs = {"MSE": MSE,
            "MAE": MAE,
            "MSLE": MSLE,
            "MAD": MAD}
    
    print("Mean Square Error: " + str(errs["MSE"]))
    print("Mean Absolute Error: " + str(errs["MAE"]))
    print("Mean Square Logarithmic Error: " + str(errs["MSLE"]))
    print("Median Absolute Deviation: " + str(errs["MAD"]) + "\n")
    
    return AL, caches_P, errs

#    if gradient_method == "SGD":   
#        for i in range(num_epochs):
#            minibatches = random_mini_batches(X, Y, mini_batch_size, seed)
#            for minibatch in minibatches:
#                (minibatch_X, minibatch_Y) = minibatch
#                m = minibatch_X.shape[1]
#                for j in range(0, m):
#                    AL, caches = forward_propagation_deep(minibatch_X[:,j], parameters)
#                    
#                    if cost_method == "MSE":
#                        cost = cost_MSE(AL, minibatch_Y[j])
#                        
#                    elif cost_method == "MAE":
#                        cost = cost_MAE(AL, minibatch_Y[j])
#                        
#                    elif cost_method == "MSLE":
#                        cost = cost_MSLE(AL, minibatch_Y[j])
#                        
#                    elif cost_method == "MAD":
#                        cost = cost_MAD(AL, minibatch_Y[j])
#                        
#                    gradients = backward_propagation_deep(AL, minibatch_Y[j], caches, lamdb)
#                    
#                    if optimizer == "gd":
#                        parameters = update_parameters_with_gd(parameters, gradients, learning_rate)
#                    elif optimizer == "momentum":
#                        parameters, v = update_parameters_with_momentum(parameters, gradients, v, beta, learning_rate)
#                    elif optimizer == "adam":
#                        t = t + 1 # Adam counter
#                        parameters, v, s = update_parameters_with_adam(parameters, gradients, v, s,
#                                                                       t, learning_rate, beta1, beta2,  epsilon)
#                    # Print the cost every 1000 epoch
#            if print_cost and i % 1000 == 0:
#                print ("Cost after epoch %i: %f" %(i, cost))
#            if print_cost and i % 100 == 0:
#                costs.append(cost)
