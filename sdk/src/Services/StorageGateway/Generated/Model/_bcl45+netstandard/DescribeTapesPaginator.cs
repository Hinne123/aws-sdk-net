#if !NETSTANDARD13
/*
 * Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

/*
 * Do not modify this file. This file is generated from the storagegateway-2013-06-30.normal.json service model.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
 
namespace Amazon.StorageGateway.Model
{
    /// <summary>
    /// Base class for DescribeTapes paginators.
    /// </summary>
    internal sealed partial class DescribeTapesPaginator : IPaginator<DescribeTapesResponse>, IDescribeTapesPaginator
    {
        private readonly IAmazonStorageGateway _client;
        private readonly DescribeTapesRequest _request;
        private int _isPaginatorInUse = 0;
        
        /// <summary>
        /// Enumerable containing all full responses for the operation
        /// </summary>
        public IPaginatedEnumerable<DescribeTapesResponse> Responses => new PaginatedResponse<DescribeTapesResponse>(this);

        /// <summary>
        /// Enumerable containing all of the Tapes
        /// </summary>
        public IPaginatedEnumerable<Tape> Tapes => 
            new PaginatedResultKeyResponse<DescribeTapesResponse, Tape>(this, (i) => i.Tapes);

        internal DescribeTapesPaginator(IAmazonStorageGateway client, DescribeTapesRequest request)
        {
            this._client = client;
            this._request = request;
        }
#if BCL
        IEnumerable<DescribeTapesResponse> IPaginator<DescribeTapesResponse>.Paginate()
        {
            if (Interlocked.Exchange(ref _isPaginatorInUse, 1) != 0)
            {
                throw new System.InvalidOperationException("Paginator has already been consumed and cannot be reused. Please create a new instance.");
            }
            PaginatorUtils.SetUserAgentAdditionOnRequest(_request);
            var marker = _request.Marker;
            DescribeTapesResponse response;
            do
            {
                _request.Marker = marker;
                response = _client.DescribeTapes(_request);
                marker = response.Marker;
                yield return response;
            }
            while (marker != null);
        }
#endif
#if AWS_ASYNC_ENUMERABLES_API
        async IAsyncEnumerable<DescribeTapesResponse> IPaginator<DescribeTapesResponse>.PaginateAsync(CancellationToken cancellationToken = default)
        {
            if (Interlocked.Exchange(ref _isPaginatorInUse, 1) != 0)
            {
                throw new System.InvalidOperationException("Paginator has already been consumed and cannot be reused. Please create a new instance.");
            }
            PaginatorUtils.SetUserAgentAdditionOnRequest(_request);
            var marker = _request.Marker;
            DescribeTapesResponse response;
            do
            {
                _request.Marker = marker;
                response = await _client.DescribeTapesAsync(_request, cancellationToken).ConfigureAwait(false);
                marker = response.Marker;
                cancellationToken.ThrowIfCancellationRequested();
                yield return response;
            }
            while (marker != null);
        }
#endif
    }
}
#endif