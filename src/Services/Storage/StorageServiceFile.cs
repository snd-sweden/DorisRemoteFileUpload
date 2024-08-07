﻿using System;

namespace DorisStorageAdapter.Services.Storage;

public record StorageServiceFile(
    string? ContentType,
    DateTime? DateCreated,
    DateTime? DateModified,
    string Path,
    long Length
) : StorageServiceFileBase(ContentType, DateCreated, DateModified);
